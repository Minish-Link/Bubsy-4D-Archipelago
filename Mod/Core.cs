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

[assembly: MelonInfo(typeof(BubsyArchipelagoMod.Bubsy4DArchi), "Bubsy 4D Archipelago Mod", "1.0.0", "Minish", null)]
[assembly: MelonGame("Fabraz | Atari", "Bubsy 4D")]

namespace BubsyArchipelagoMod
{
    public class Bubsy4DArchi : MelonMod
    {
        public static bool isDebug =
#if DEBUG
    true;
#else
    false;
#endif

        public static string currentSceneName = "";
        private static KeyCode saveJsonKey;
        public static Il2CppSystem.Random rng;

        public static bool Connected;
        public static string PlayerName = "";
        public static ArchipelagoSession session;

        public override void OnInitializeMelon()
        {
            CollectableID.InitializeLocationIDs();
            LoggerInstance.Msg("Archipelago Mod Initialized.");
            saveJsonKey = KeyCode.J;
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
            {
                MoveToggleCheat.ReadCheatInputs();
            }
            else
            {
                MoveToggleCheat.Initialize();
            }
            if (Input.GetKeyDown(saveJsonKey))
            {
                //if (SaveDataManager.Instance && SaveDataManager.Instance.CurrentSaveData)
                //{
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("6f376261-3fec-41d5-9245-f5d3cf589256", true); // Baarbee Cutscene
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("5ce3d8ff-05df-415e-8780-f85c12aad031", true); // Terry and Terri Cutscene
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("143e2057-16da-4a62-9f1b-691232af8786", true); // Allows Map Access
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("1ea330b4-8a3a-486e-9d8e-309273ec6acd", true); // Opens Shop
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("f1b9ccfb-51d8-4cd0-b29b-a433b491b663", true); // Baaptiste Defeated
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("10a5e75b-49be-4f5d-b028-496df96df79a", true); // Oblivia Dialogue (Black Hole)
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("4d59705f-b9dc-49c4-be51-f4d6734450c7", true); // Gauntlet Unlock
                //    SaveDataManager.Instance.CurrentSaveData.SetWorldState("f84886d8-d6e2-49ce-bf4f-b627156ddb1a", true); // Gauntlet Unlock Cutscene
                //}
                BubsyInstance.SayTheLineBubsy();
                ShopHelper.ReceiveYarnballs(10);

            }
        }

        public static void OnItemReceived(ReceivedItemsHelper itemHelper)
        {

        }

        public static void ConnectToAP(string serverAddress, string userName, string password)
        {
            session = ArchipelagoSessionFactory.CreateSession(serverAddress);

            session.Items.ItemReceived += OnItemReceived;

            LoginResult result;

            try
            {
                result = session.TryConnectAndLogin("Bubsy 4D", userName, ItemsHandlingFlags.AllItems);
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
            MelonLogger.Msg($"{userName} Successfully connected to {serverAddress}");
            Connected = true;

            if (ConnectionGUI.Instance)
            {

            }

            MoveInventory.LockAllMoveItems();
            ObjectInventory.LockAllItems();
        }
    }
}