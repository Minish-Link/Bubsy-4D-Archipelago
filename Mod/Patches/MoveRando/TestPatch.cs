
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.PlayerCharacter;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI.Atari;
using MelonLoader;
using UnityEngine;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(SaveData), nameof(SaveData.SetWorldState))]
public static class TestPatch
{
    public static void Prefix(string id, bool state)
    {
        MelonLogger.Msg($"{id} : {state}");
    }
}