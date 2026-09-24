using HarmonyLib;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Instances;

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.Awake))]
public static class ShopInstance
{
    public static GearShopMenu Instance;

    static void Postfix(GearShopMenu __instance)
    {
        Instance = __instance;
        MelonLogger.Msg(ConsoleColor.Green, "Shop's Open");
    }
}
