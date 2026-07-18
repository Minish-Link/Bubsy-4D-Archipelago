/*
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.Interactables.Atari;
using MelonLoader;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(AmpelmannChallenge), nameof(AmpelmannChallenge.Update))]
public static class AmpelmannPatch
{
    public static void Postfix(ref AmpelmannChallenge __instance)
    {
        if (__instance.active && ObjectInventory.Ampelmann)
        {
            MelonLogger.Msg("Cancel Ampelmann");
            __instance.CancelChallenge(true);
        }
        //return ObjectInventory.Ampelmann;
    }
}
*/