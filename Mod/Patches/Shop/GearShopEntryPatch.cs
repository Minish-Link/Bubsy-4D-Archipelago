
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.UI.Atari;

namespace BubsyArchipelagoMod.Patches.Shop;

[HarmonyPatch(typeof(GearShopEntry), "SetItemData")]
public static class GearShopEntryPatch
{
    public static void Prefix(ref ItemData newData, ref bool available, ref GearShopEntry __instance)
    {

    }
    public static void Postfix(ItemData newData, ref GearShopEntry __instance)
    {
        
    }
}

[HarmonyPatch(typeof(GearShopEntry), "Select")]
public static class GearShopSelectPatch
{
    public static bool Prefix(GearShopEntry __instance)
    {
        return true;
        
        //return __instance.itemData.nameContent != "Bubsy 3D";
    }
}