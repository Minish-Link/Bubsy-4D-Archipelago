using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;

namespace BubsyArchipelagoMod.Instances;

[HarmonyPatch(typeof(BubsyCharacterController), nameof(BubsyCharacterController.Start))]
public static class BubsyInstance
{
    public static BubsyCharacterController Instance;

    public static void Postfix(BubsyCharacterController __instance)
    {
        MelonLogger.Msg(ConsoleColor.Green, "Bubsy has awoken");
        Instance = __instance;
    }
}