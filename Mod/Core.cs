using BubsyArchipelagoMod.Cheats;
using BubsyArchipelagoMod.Helpers;
using MelonLoader;
using UnityEngine;
using Newtonsoft.Json;
using Il2CppFabraz.SaveData;

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
                }
            }
        }


        public static void LogPatchMessage(string message, LogType logType = LogType.DEFAULT)
        {
            if (allowedLogTypes[logType])
            {
                PublicLogInstance.Msg(message);
            }
        }

        private static Dictionary<LogType, bool> allowedLogTypes = new Dictionary<LogType, bool>()
        {
            {LogType.DEFAULT, false },
            {LogType.MOVE_RANDO, false },
            {LogType.COLLECTABLE, true },
            {LogType.LEVEL, true }
        };
    }
    public enum LogType
    {
        DEFAULT,
        MOVE_RANDO,
        COLLECTABLE,
        LEVEL
    }
}