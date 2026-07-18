using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI.Atari;
using Unity.Collections;
using UnityEngine;

namespace BubsyArchipelagoMod.Patches.Shop;

[HarmonyPatch(typeof(GearShopMenu), "PopulateEntries", [typeof(int), typeof(bool)])]
[HarmonyPatch(typeof(GearShopMenu), "PopulateEntries", [typeof(int)])]
public static class GearShopPopulatePatch
{
    private static bool apInitialized = false;

    public static void Prefix(ref GearShopMenu __instance)
    {
        if (!apInitialized)
        {
            Bubsy4DArchi.LogPatchMessage("Initializing Gear Shop");
            apInitialized = true;
            //ItemData newItemData = UnityEngine.ScriptableObject.Instantiate(__instance.upgradesData[0], __instance.transform);
            //newItemData.currencyType = __instance.currencyTypeYarnball;
            //newItemData.blockedInDemo = false;
            //newItemData.descriptionContent = "D";
            //newItemData.hiddenInNineLifesMode = false;
            //newItemData.nameContent = "N";
            //newItemData.price = 175;
        }
    }

    public static void Postfix(ref GearShopMenu __instance)
    {
        for (int i = 0; i < __instance.currentEntries.Count; i++)
        {
            GearShopEntry entry = __instance.currentEntries[i];
            if (!VanillaShopHelper.HasSkinOrUpgrade(entry.itemData.nameContent))
            {
                entry.itemData.price = 999999;
                entry.cost.text = "N/A";
                entry.label.color = entry.unavailableColor;
                entry.label.text += "(Not Found)";
            }
        }
    }
}