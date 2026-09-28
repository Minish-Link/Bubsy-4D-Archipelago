using HarmonyLib;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.Menus;

[HarmonyPatch(typeof(TitleMenu), nameof(TitleMenu.ShowMenu))]
public static class ShowTitleMenuPatch
{
    static void Postfix(TitleMenu __instance)
    {
        MelonLogger.Msg("Show Title Menu");
    }
}