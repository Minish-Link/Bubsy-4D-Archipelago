using BubsyArchipelagoMod.Cheats;
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
        public static bool isDebug = true;

        public override void OnInitializeMelon()
        {
            PublicLogInstance = LoggerInstance;
            LoggerInstance.Msg("Archipelago Mod Initialized.");
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
            if (MoveToggleCheat.Initialized)
            {
                MoveToggleCheat.ReadCheatInputs();
            }
            else
            {
                MoveToggleCheat.Initialize();
            }
        }

        public static void LogPatchMessage(string message)
        {
            PublicLogInstance.Msg(message);
        }
    }
}