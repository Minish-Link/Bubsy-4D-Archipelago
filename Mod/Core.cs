using BubsyArchipelagoMod.Cheats;
using BubsyArchipelagoMod.Helpers;
using MelonLoader;
using UnityEngine;
using Newtonsoft.Json;
using Il2CppFabraz.SaveData;
using BubsyArchipelagoMod.Data;

[assembly: MelonInfo(typeof(BubsyArchipelagoMod.Bubsy4DArchi), "Bubsy 4D Archipelago Mod", "1.0.0", "Minish", null)]
[assembly: MelonGame("Fabraz | Atari", "Bubsy 4D")]

namespace BubsyArchipelagoMod
{
    public class Bubsy4DArchi : MelonMod
    {
        public static MelonLogger.Instance PublicLogInstance;
        public static bool isDebug = true;
        public static string currentSceneName = "";
        private static KeyCode saveJsonKey;

        public override void OnInitializeMelon()
        {
            PublicLogInstance = LoggerInstance;
            CollectableID.InitializeLocationIDs();
            LoggerInstance.Msg("Archipelago Mod Initialized.");
            saveJsonKey = KeyCode.J;
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            LoggerInstance.Msg($"Scene {sceneName} was loaded.");
            currentSceneName = sceneName;
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
                if (SaveDataManager.Instance && SaveDataManager.Instance.CurrentSaveData)
                {
                    SaveDataManager.Instance.CurrentSaveData.SetWorldState("6f376261-3fec-41d5-9245-f5d3cf589256", true); // Baarbee Cutscene
                    SaveDataManager.Instance.CurrentSaveData.SetWorldState("5ce3d8ff-05df-415e-8780-f85c12aad031", true); // Terry and Terri Cutscene
                    SaveDataManager.Instance.CurrentSaveData.SetWorldState("143e2057-16da-4a62-9f1b-691232af8786", true); // Allows Map Access
                    SaveDataManager.Instance.CurrentSaveData.SetWorldState("1ea330b4-8a3a-486e-9d8e-309273ec6acd", true); // Opens Shop
                    SaveDataManager.Instance.CurrentSaveData.SetWorldState("f1b9ccfb-51d8-4cd0-b29b-a433b491b663", true); // Baaptiste Defeated
                    SaveDataManager.Instance.CurrentSaveData.SetWorldState("10a5e75b-49be-4f5d-b028-496df96df79a", true); // Oblivia Dialogue (Black Hole)
                }
            }
        }
    }
}