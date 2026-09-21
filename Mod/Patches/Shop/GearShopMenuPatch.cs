using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using MelonLoader;
using Unity.Collections;
using UnityEngine;

namespace BubsyArchipelagoMod.Patches.Shop;

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.PopulateEntries), [typeof(int), typeof(bool)])]
[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.PopulateEntries), [typeof(int)])]
public static class GearShopPopulatePatch
{
    public static bool Prefix(int category, GearShopMenu __instance)
    {
        MelonLogger.Msg(ConsoleColor.Blue, category);
        __instance.ClearEntries();
        if (category == 0)
        {
            foreach (var upgrade in __instance.upgradesData)
            {
                GearShopEntry newEntry = UnityEngine.Object.Instantiate(__instance.entryEquipPrefab);
                newEntry.transform.SetParent(__instance.contentRoot);
                newEntry.SetItemData(upgrade, __instance.currencySprites[upgrade.currencyType], true);
                newEntry.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                __instance.currentEntries.Add(newEntry);
            }
            foreach (var skin in __instance.outfitsData)
            {
                GearShopEntry newEntry = UnityEngine.Object.Instantiate(__instance.entryEquipPrefab);
                newEntry.transform.SetParent(__instance.contentRoot);
                newEntry.SetItemData(skin, __instance.currencySprites[skin.currencyType], true);
                newEntry.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                MelonLogger.Msg(newEntry.itemData.nameContent);
                //__instance.bubsyCharacterController
                __instance.currentEntries.Add(newEntry);
            }
        }
        else if (category == 1)
        {
            __instance.ClearEntries();
            ShopHelper.InitializeAPItemData(__instance);
            foreach (ItemData apData in ShopHelper.currentItemDatas)
            {
                MelonLogger.Msg(apData);
                GearShopEntry newEntry = UnityEngine.Object.Instantiate(__instance.entryPurchasePrefab);
                newEntry.transform.SetParent(__instance.contentRoot);
                newEntry.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                newEntry.currencyIcon = (UnityEngine.UI.Image)__instance.currencySprites[apData.currencyType].Asset;
                newEntry.cost.text = apData.price.ToString();
                newEntry.label.text = apData.nameContent;
                newEntry.description.text = apData.descriptionContent;
                newEntry.itemData = apData;

                FzButton entryButton = newEntry.GetComponent<FzButton>();
                if (entryButton)
                {
                    entryButton.onClick.AddListener((UnityEngine.Events.UnityAction)ShopHelper.OnAPEntryClicked);
                    newEntry.add_onSelect((Il2CppSystem.Action<GearShopEntry>)ShopHelper.OnAPEntrySelected);
                }

                __instance.currentEntries.Add(newEntry);
            }
        }
        
        return false;
    }

    // IMPORTANT NOTES FOR FUTURE ERIK
    // Entry game objects and list of currentEntries are separate entities
    // Instead of trying to make a third category, combine skins and upgrades into one category.
    // And the AP items in the other category.
    // Look into adding only obtained outfits and upgrades to the category by manually populating the entries
    // Use the class's prefabs, and figure out how to add them to the physical menu and not just the list.
    // Might need to investigate more in Unity Explorer for this.
    // GearShopMenu.contentRoot
    public static void Postfix(ref GearShopMenu __instance)
    {
        
    }
}

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.OnEnable))]
public static class GearShopEnablePatch
{
    public static void Prefix(ref GearShopMenu __instance)
    {
        ShopHelper.OpenMenu(ref __instance);
        MelonLogger.Msg("Gear Shop Enable");
    }
}

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.OnDisable))]
public static class GearShopDisablePatch
{
    public static void Prefix()
    {
        ShopHelper.CloseMenu();
        MelonLogger.Msg("Gear Shop Disable");
    }
}