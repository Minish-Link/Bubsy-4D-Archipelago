using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;

using BubsyArchipelagoMod.Cheats;
using BubsyArchipelagoMod.Helpers;
using MelonLoader;
using UnityEngine;
using Newtonsoft.Json;
using Il2CppFabraz.SaveData;
using BubsyArchipelagoMod.Data;
using BubsyArchipelagoMod.Instances;
using Archipelago.MultiClient.Net.Helpers;
using BubsyArchipelagoMod.ModGUI;
using BubsyArchipelagoMod.Server;
using Archipelago.MultiClient.Net.Models;
using System.Collections;

[assembly: MelonInfo(typeof(BubsyArchipelagoMod.Core), "Bubsy 4D Archipelago Mod", "0.1.0", "Minish", null)]
[assembly: MelonGame("Fabraz | Atari", "Bubsy 4D")]

namespace BubsyArchipelagoMod
{
    public class Core : MelonMod
    {
        public static bool isDebug =
#if DEBUG
    true;
#else
    false;
#endif

        // Increment this by 1 each time the mod is made incompatible with previous versions of the apworld.
        public const int versionCompatability = 1;

        public static string currentSceneName = "";
        private static KeyCode debugTestKey;
        public static Il2CppSystem.Random rng;

        public static bool Connected;
        public static string PlayerName = "";
        public static ArchipelagoSession session;

        public override void OnInitializeMelon()
        {
            CollectableID.InitializeLocationIDs();
            LoggerInstance.Msg("Archipelago Mod Initialized.");
            debugTestKey = KeyCode.J;
            rng = new Il2CppSystem.Random();

            Connected = false;
            MoveInventory.UnlockAllMoveItems();
            ObjectInventory.UnlockAllObjectItems();
            LevelUnlockHelper.UnlockAllLevels();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            LoggerInstance.Msg($"Scene {sceneName} was loaded.");
            currentSceneName = sceneName;
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            base.OnSceneWasInitialized(buildIndex, sceneName);
            if (sceneName.Length >= 6 && (sceneName.Substring(0,6) == "Planet" || sceneName.Substring(0,6) == "Tutori"))
                ObjectDisabler.TryDisableObjects(sceneName);
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasUnloaded(buildIndex, sceneName);
            ObjectDisabler.ClearObjects();
            
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (MoveToggleCheat.Initialized)
                MoveToggleCheat.ReadCheatInputs();
            else
                MoveToggleCheat.Initialize();

            if (Connected)
            {
                SaveDataInstance.UpdateCollectableCounts();
                ReceivedItemHandler.HandleNextItem();
            }

            if (isDebug && Input.GetKeyDown(debugTestKey))
            {
                //
            }
        }

        private static bool attemptingConnection = false;

        public static string[] TryConnectToAP(string serverAddress, string userName, string password)
        {
            if (attemptingConnection)
                return ["Connecting..."];
            attemptingConnection = true;

            session = ArchipelagoSessionFactory.CreateSession(serverAddress);
            session.Items.ItemReceived += OnItemReceived;

            LoginResult result;

            try
            {
                result = session.TryConnectAndLogin("Bubsy 4D", userName, ItemsHandlingFlags.NoItems);
            }
            catch (Exception exception)
            {
                result = new LoginFailure(exception.GetBaseException().Message);
            }

            if (!result.Successful)
            {
                LoginFailure failure = (LoginFailure)result;
                MelonLogger.Error($"Failed to Connect to server at {serverAddress}");
                foreach (string error in failure.Errors)
                {
                    MelonLogger.Error(error);
                }
                foreach (ConnectionRefusedError error in failure.ErrorCodes)
                {
                    MelonLogger.Error(error);
                }

                attemptingConnection = false;

                return failure.Errors;
            }

            // Successful Connection
            var loginSuccess = (LoginSuccessful)result;
            int sdResult = SlotData.LoadSlotData(loginSuccess.SlotData);
            if (sdResult != 0)
            {
                attemptingConnection = false;
                string[] errorMessages = [
                    $"This seed was generated with a {((sdResult > 0) ? "n older" : " newer")} version of the apworld.",
                    $"Download a version of the mod that's compatible with version {SlotData.apworldVersion} of the apworld and try again."
                ];
                MelonLogger.Msg(System.ConsoleColor.Red, string.Join(' ',errorMessages));
                session.Socket.DisconnectAsync();
                return errorMessages;
            }

            MelonLogger.Msg($"{userName} Successfully connected to {serverAddress}");
            Connected = true;
            attemptingConnection = false;

            //SaveDataInstance.ResetCollectableCounts();
            MoveInventory.LockAllMoveItems();
            ObjectInventory.LockAllObjectItems();
            LevelUnlockHelper.LockAllLevels();
            MelonCoroutines.Start(ScoutAllLocations(session.Locations.AllLocations.ToArray()));
            MelonCoroutines.Start(HintAllShopItems());
            MelonLogger.Msg(session.RoomState.Seed);
            //session.ConnectionInfo.UpdateConnectionOptions(ItemsHandlingFlags.AllItems);

            return null;
        }

        public static void StartReceivingItems(bool receiving = true)
        {
            if (session is null)
                return;
            session.ConnectionInfo.UpdateConnectionOptions(ItemsHandlingFlags.AllItems);
        }

        public static void ForceDisconnect()
        {
            Connected = false;
            if (session is null)
                return;
            session.Socket.DisconnectAsync();
        }

        public static void OnItemReceived(ReceivedItemsHelper itemHelper)
        {
            //MelonLogger.Msg("We just got an item!");
            var receivedItem = itemHelper.PeekItem();
            //MelonLogger.Msg($"{receivedItem.ItemName}, {receivedItem.ItemDisplayName}");
            //MelonLogger.Msg($"{itemHelper.Index} items from the server so far");
            //itemHelper.DequeueItem();
            //return;
            if (receivedItem != null)
            {
                ReceivedItemHandler.QueueItem(receivedItem.ItemName);
            }

            //ReceivedItemHandler.HandleItem()
            itemHelper.DequeueItem();
        }


        public static Dictionary<long, ScoutedItemInfo> ScoutedItems;

        public static IEnumerator ScoutAllLocations(params long[] ids)
        {
            Task<Dictionary<long, ScoutedItemInfo>> task = session.Locations.ScoutLocationsAsync(HintCreationPolicy.None, ids);
            yield return new WaitUntil(new Func<bool>(() => task.IsCompleted));

            ScoutedItems = new Dictionary<long, ScoutedItemInfo>(task.Result);
        }

        public static IEnumerator HintAllShopItems()
        {
            List<long> ids = new List<long>(200);
            for (int i = 1; i < 201; i++)
                _ = ids.Append(i);
            var task = session.Locations.ScoutLocationsAsync(HintCreationPolicy.CreateAndAnnounceOnce, ids.ToArray());
            yield return new WaitUntil(new Func<bool>(() => task.IsCompleted));
        }

        private static SortedSet<long> m_AllCheckedLocations = new SortedSet<long>();

        public static void SendLocationIDs(params long[] ids)
        {
            if (session == null)
                return;
            foreach (long id in ids)
                m_AllCheckedLocations.Add(id);
            session.Locations.CompleteLocationChecks(ids);
        }

        public static void SendCollectableLocation(string locationID)
        {
            int apID = CollectableID.GetLocationID(locationID);
            if (apID == 0)
                return;
            m_AllCheckedLocations.Add(apID);
            if (session == null)
                return;
            session.Locations.CompleteLocationChecks(apID);
        }

        public static void ResendAllCheckedLocations()
        {
            if (session == null)
                return;
            long[] ids = m_AllCheckedLocations.ToArray();
            session.Locations.CompleteLocationChecks(ids);
        }

        public static bool WasLocationChecked(long id)
        {
            if (session == null)
                return false;
            return session.Locations.AllLocationsChecked.Contains(id);
        }

        public static string GetSaveFileIdentifier()
        {
            if (session is null)
                return "Null Identifier";
            return $"{session.Players.ActivePlayer.Name}_{session.RoomState.Seed}";
        }
    }
}