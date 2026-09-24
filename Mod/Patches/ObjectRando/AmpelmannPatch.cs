using BubsyArchipelagoMod.Helpers;
using BubsyArchipelagoMod.Instances;
using HarmonyLib;
using Il2CppFabraz.Interactables.Atari;
using MelonLoader;
namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(AmpelmannChallenge), nameof(AmpelmannChallenge.TriggerChallenge))]
public static class AmpelmannPatch
{
    public static void Postfix(AmpelmannChallenge __instance)
    {
        __instance.CancelChallenge();
    }
}