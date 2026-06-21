using BubsyArchipelagoMod.Helpers;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(BubsyArchipelagoMod.Bubsy4DArchi), "Bubsy 4D Archipelago Mod", "1.0.0", "Minish", null)]
[assembly: MelonGame("Fabraz | Atari", "Bubsy 4D")]

namespace BubsyArchipelagoMod
{
    public class Bubsy4DArchi : MelonMod
    {
        public static MelonLogger.Instance PublicLogInstance;
        private static KeyCode temp_debug_key;
        public static bool isDebug = true;

        public override void OnInitializeMelon()
        {
            PublicLogInstance = LoggerInstance;
            LoggerInstance.Msg("Archipelago Mod Initialized.");
            temp_debug_key = KeyCode.O;
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            base.OnSceneWasInitialized(buildIndex, sceneName);
            LoggerInstance.Msg($"Scene {sceneName} was initialized.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            base.OnSceneWasLoaded(buildIndex, sceneName);
            LoggerInstance.Msg($"Scene {sceneName} was loaded.");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Input.GetKeyDown(temp_debug_key) && isDebug)
            {
                MoveInventory.Jump = !MoveInventory.Jump;
            }
        }

        public static void LogPatchMessage(string message)
        {
            PublicLogInstance.Msg(message);
        }
    }
}