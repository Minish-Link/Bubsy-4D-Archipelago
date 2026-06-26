using Il2CppFabraz;
using HarmonyLib;
using Il2CppFabraz.Bubsy;
using Newtonsoft.Json;

namespace BubsyArchipelagoMod.Patches.Collectables;

[HarmonyPatch(typeof(Yarnball), "Collect")]
public static class CollectableSendPatch
{
    public static void Prefix(Yarnball __instance)
    {
        Bubsy4DArchi.LogPatchMessage($"Collecting {__instance.getValue}x Yarnball with ID: {__instance.id.getID}", LogType.COLLECTABLE);
        Bubsy4DArchi.AddCollectableToDict(Bubsy4DArchi.currentSceneName, __instance.id.getID, __instance.getValue.ToString());
    }
}
