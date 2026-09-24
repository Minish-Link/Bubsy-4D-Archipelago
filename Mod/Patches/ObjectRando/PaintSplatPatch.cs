using BubsyArchipelagoMod.Instances;
using HarmonyLib;
using Il2CppFabraz.Interactables;
using Il2CppFabraz.Interactables.Atari;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;
using UnityEngine;

namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(BubsyCharacterController), nameof(BubsyCharacterController.TriggerCameraPaintSplat), [typeof(int)])]
public static class ToxicPaintPatch
{
    public static void Postfix(BubsyCharacterController __instance)
    {
        MelonLogger.Msg("Splat!");
        if (__instance.life.health.currentHealth > 0)
        {
            __instance.life.health.TakeDamage(1, Vector3.up);
        }
    }
}
