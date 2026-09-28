/*
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.ObjectRando;

[HarmonyPatch(typeof(CharacterAttackTarget), MethodType.Constructor)]
public static class PinheadPatch
{
    public static void Postfix(CharacterAttackTarget __instance)
    {
        MelonLogger.Msg("CharacterAttackTarget");
        __instance.active = false;
    }
}
*/