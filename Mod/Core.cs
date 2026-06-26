using BubsyArchipelagoMod.Cheats;
using BubsyArchipelagoMod.Helpers;
using MelonLoader;
using UnityEngine;
using Newtonsoft.Json;

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
                SaveCollectibleIDsToJson();
            }
        }
        private static string jsonCollectableDataPath = "E:\\Bubsy4DMod\\GitHub\\Bubsy-4D-Archipelago\\Data\\Collectible_IDs.json";
        private static Dictionary<string, Dictionary<string, string>> tempCollectableIDDict = new Dictionary<string, Dictionary<string, string>>();
        public static void AddCollectableToDict(string sceneName, string collectableID, string collectableType)
        {
            if (!tempCollectableIDDict.ContainsKey(sceneName))
            {
                tempCollectableIDDict.Add(sceneName, new Dictionary<string, string>());
            }
            if (!tempCollectableIDDict[sceneName].ContainsKey(collectableID))
            {
                tempCollectableIDDict[sceneName].Add(collectableID, collectableType);
            }
        }

        private static void SaveCollectibleIDsToJson()
        {
            PublicLogInstance.Msg(tempCollectableIDDict);
            PublicLogInstance.Msg(jsonCollectableDataPath);
            File.WriteAllText(jsonCollectableDataPath, JsonConvert.SerializeObject(tempCollectableIDDict));
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
            {LogType.DEFAULT, true },
            {LogType.MOVE_RANDO, true },
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