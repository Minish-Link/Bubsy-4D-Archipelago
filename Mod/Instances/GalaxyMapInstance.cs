using HarmonyLib;
using Il2CppFabraz.UI.Atari;

namespace BubsyArchipelagoMod.Instances;

[HarmonyPatch(typeof(GalaxyMapController), nameof(GalaxyMapController.Start))]
public static class GalaxyMapInstance
{
    public static GalaxyMapController Instance;

    public static void Postfix(GalaxyMapController __instance)
    {
        Instance = __instance;
    }

    public static string GetCurrentLevelName()
    {
        if (!Instance || !Instance.activePlanet)
            return "";
        return Instance.activePlanet.levelName;
    }
}
