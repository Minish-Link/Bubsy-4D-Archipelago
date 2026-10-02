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
            ObjectInventory.UnlockAllItems();
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
                ReceivedItemHandler.HandleNextItem();
            }

            if (Input.GetKeyDown(debugTestKey))
            {
                SaveDataInstance.SetWorldState("6f376261-3fec-41d5-9245-f5d3cf589256", true); // Baarbee Cutscene
                SaveDataInstance.SetWorldState("5ce3d8ff-05df-415e-8780-f85c12aad031", true); // Terry and Terri Cutscene
                SaveDataInstance.SetWorldState("143e2057-16da-4a62-9f1b-691232af8786", true); // Allows Map Access
                SaveDataInstance.SetWorldState("1ea330b4-8a3a-486e-9d8e-309273ec6acd", true); // Opens Shop
                SaveDataInstance.SetWorldState("f1b9ccfb-51d8-4cd0-b29b-a433b491b663", true); // Baaptiste Defeated
                SaveDataInstance.SetWorldState("10a5e75b-49be-4f5d-b028-496df96df79a", true); // Oblivia Dialogue (Black Hole)
                SaveDataInstance.SetWorldState("4d59705f-b9dc-49c4-be51-f4d6734450c7", true); // Gauntlet Unlock
                SaveDataInstance.SetWorldState("f84886d8-d6e2-49ce-bf4f-b627156ddb1a", true); // Gauntlet Unlock Cutscene
                SaveDataInstance.SetWorldState("e226a1eb-c8ff-481b-b65a-ddf3a1b0c07c", true); // Virgil Interruption in 1-3
                //BubsyInstance.SayTheLineBubsy();
                //ShopHelper.ReceiveYarnballs(10);
                ConnectToAP("localhost:38281", "Player1", "");
            }
        }

        public static void ConnectToAP(string serverAddress, string userName, string password)
        {
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

                // TODO Update Connect Menu

                return;
            }

            // Successful Connection
            var loginSuccess = (LoginSuccessful)result;
            int sdResult = SlotData.LoadSlotData(loginSuccess.SlotData);
            if (sdResult != 0)
            {
                MelonLogger.Msg(System.ConsoleColor.Red, $"This seed was generated with a{((sdResult > 0) ? "n older" : " newer") } version of the apworld.\n" +
                    $"Download a version of the mod that's compatible with version {SlotData.apworldVersion} of the apworld and try again.");
                session.Socket.DisconnectAsync();
                // TODO Display an error on the Connection GUI
                return;
            }
            MelonLogger.Msg("Slot Data finished Loading");

            MelonLogger.Msg($"{userName} Successfully connected to {serverAddress}");
            Connected = true;

            if (ConnectionGUI.Instance)
            {
                // TODO
            }

            SaveDataInstance.ResetCollectableCounts();
            MoveInventory.LockAllMoveItems();
            ObjectInventory.LockAllItems();
            MelonCoroutines.Start(ScoutAllLocations(session.Locations.AllLocations.ToArray()));
            session.ConnectionInfo.UpdateConnectionOptions(ItemsHandlingFlags.AllItems);
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
    }
}