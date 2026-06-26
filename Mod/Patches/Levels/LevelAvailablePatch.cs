
using HarmonyLib;
using Il2CppFabraz.UI.Atari;

namespace BubsyArchipelagoMod.Patches.Levels;

[HarmonyPatch(typeof(GalaxyPlanetNode), "PlanetIsAccessible")]
public static class LevelAvailablePatch
{
    public static bool Postfix(GalaxyPlanetNode __instance)
    {
        Bubsy4DArchi.LogPatchMessage(__instance.ToString(), LogType.LEVEL);
        return true;
    }
}
