
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.Interactables;
using MelonLoader;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(ForceBounce), nameof(ForceBounce.OnCollisionEnter))]
[HarmonyPatch(typeof(ForceBounce), nameof(ForceBounce.OnTriggerEnter))]
public static class DisableBubblePatch
{
    public static void Postfix()
    {
        MelonLogger.Msg("Force Bounce here");
    }
}
