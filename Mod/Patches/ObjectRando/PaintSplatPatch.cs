using BubsyArchipelagoMod.Instances;
using HarmonyLib;
using Il2CppFabraz.Interactables;
using Il2CppFabraz.Interactables.Atari;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;
using UnityEngine;

namespace BubsyArchipelagoMod.Patches.ObjectRando;

// Unity Explorer really doesn't like this one for some reason
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
