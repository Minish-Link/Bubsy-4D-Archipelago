using Il2CppFabraz;
using HarmonyLib;
using Il2CppFabraz.Bubsy;
using Newtonsoft.Json;

namespace BubsyArchipelagoMod.Patches.Collectables;

[HarmonyPatch(typeof(Collectable), "Collect")]
public static class CollectableSendPatch
{
    public static void Prefix(Collectable __instance)
    {
        Bubsy4DArchi.LogPatchMessage($"Collecting object with ID: {__instance.id.getID}", LogType.COLLECTABLE);
        //Bubsy4DArchi.AddCollectableToDict(Bubsy4DArchi.currentSceneName, __instance.id.getID, __instance.getValue.ToString());
    }
}
