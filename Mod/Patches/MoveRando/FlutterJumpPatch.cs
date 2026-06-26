using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyCharacterController), "CanFlutterJump")]
public static class FlutterJumpPatch
{
    public static bool Prefix()
    {
        return MoveInventory.FlutterStep;
    }
}