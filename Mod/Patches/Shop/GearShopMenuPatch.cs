using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using MelonLoader;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BubsyArchipelagoMod.Patches.Shop;

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.PopulateEntries), [typeof(int), typeof(bool)])]
[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.PopulateEntries), [typeof(int)])]
public static class GearShopPopulatePatch
{
    public static bool Prefix(int category, GearShopMenu __instance)
    {
        if (!ShopHelper.overrideEntries)
        {
            return true;
        }
        MelonLogger.Msg(ConsoleColor.Blue, category);
        if (category == 0)
        {
            if (ShopHelper.overrideEntries)
            {
                __instance.ClearEntries();
                ShopHelper.overrideEntries = false;
                __instance.PopulateEntries(0, true);
                __instance.PopulateEntries(1, true);
                ShopHelper.overrideEntries = true;
                return false;
            }
            /*
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
            */
        }
        else if (category == 1)
        {
            __instance.ClearEntries();
            foreach (ItemData apData in ShopHelper.currentItemDatas)
            {
                GearShopEntry newEntry = UnityEngine.Object.Instantiate(__instance.entryPurchasePrefab);
                newEntry.transform.SetParent(__instance.contentRoot);
                newEntry.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                //newEntry.cost.text = apData.price.ToString();
                //newEntry.label.text = apData.nameContent;
                //newEntry.description.text = apData.descriptionContent;
                //newEntry.itemData = apData;
                //newEntry.currencyIcon = __instance.currencySprites[apData.currencyType].
                newEntry.SetItemData(apData, __instance.currencySprites[apData.currencyType], true);
                newEntry.label.text = apData.nameContent;
                newEntry.description.text = apData.descriptionContent;

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

    public static void Postfix(int category, GearShopMenu __instance)
    {
        if (category == 1)
            return;
        for (int i = __instance.currentEntries.Count - 1; i >= 0; i--)
        {
            FzToggle throwaway;
            if (!__instance.currentEntries[i].IsToggle(out throwaway))
            {
                UnityEngine.Object.Destroy(__instance.currentEntries[i].gameObject);
                __instance.currentEntries.RemoveAt(i);
            }
        }
    }
}

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.ClearEntries))]
public static class GearShopClearPatch
{
    public static bool Prefix()
    {
        return ShopHelper.overrideEntries;
    }
}

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.OnEnable))]
public static class GearShopEnablePatch
{
    public static void Prefix(ref GearShopMenu __instance)
    {
        ShopHelper.OpenMenu(ref __instance);
        MelonLogger.Msg("Gear Shop Enable");
        ShopHelper.InitializeAPItemData(ref __instance);
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