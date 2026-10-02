using Archipelago.MultiClient.Net.Models;
using BubsyArchipelagoMod.Components;
using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BubsyArchipelagoMod.Patches.Shop;

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.PopulateEntries), [typeof(int), typeof(bool)])]
[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.PopulateEntries), [typeof(int)])]
public static class GearShopPopulatePatch
{
    private static List<GearShopEntry> tempUpgradesList = new List<GearShopEntry>();

    public static bool Prefix(int category, GearShopMenu __instance)
    {
        if (!ShopHelper.overrideEntries)
        {
            return true;
        }
        MelonLogger.Msg(ConsoleColor.Blue, category);
        if (category == 1)
        {
            if (ShopHelper.overrideEntries)
            {
                tempUpgradesList.Clear();
                __instance.ClearEntries();
                ShopHelper.overrideEntries = false;
                __instance.PopulateEntries(0, true);
                foreach (GearShopEntry entry in __instance.currentEntries)
                {
                    tempUpgradesList.Add(entry);
                }
                __instance.currentEntries.Clear();
                __instance.PopulateEntries(1, true);
                foreach(GearShopEntry entry in tempUpgradesList)
                {
                    __instance.currentEntries.Add(entry);
                }

                ShopHelper.overrideEntries = true;
                return false;
            }
        }
        else if (category == 0)
        {
            ShopHelper.InitializeAPItemData(__instance);
            MelonLogger.Msg(ShopHelper.currentItemDatas.Count);
            __instance.ClearEntries();
            List<ItemData> itemDatas = ShopHelper.currentItemDatas;
            for (int i = 0; i < itemDatas.Count; i++)
            {
                GearShopEntry newEntry = UnityEngine.Object.Instantiate(__instance.entryPurchasePrefab);
                newEntry.transform.SetParent(__instance.contentRoot);
                newEntry.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                newEntry.SetItemData(itemDatas[i], __instance.currencySprites[itemDatas[i].currencyType], true);
                //newEntry.label.text = itemDatas[i].nameContent;
                //newEntry.description.text = itemDatas[i].descriptionContent;

                ShopEntryData newEntryData = newEntry.gameObject.AddComponent<ShopEntryData>();
                MelonLogger.Msg(newEntryData);
                if (Core.ScoutedItems != null && Core.ScoutedItems.TryGetValue(i+1, out ScoutedItemInfo scoutedItem))
                {
                    //Core.ScoutedItems.TryGetValue(i+1, out ScoutedItemInfo scoutedItem);
                    MelonLogger.Msg(scoutedItem);
                    newEntryData.InitializeData(scoutedItem.ItemDisplayName, scoutedItem.Player.Name, scoutedItem.ItemGame, scoutedItem.LocationId);
                }
                else
                {
                    newEntryData.InitializeData($"Undefined Item {i + 1}", "Unknown Player", "Unknown Game", i + 1);
                }
                newEntry.label.text = newEntryData.ItemName;
                newEntry.description.text = $"For {newEntryData.PlayerName} ({newEntryData.GameName})";

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
        if (category == 0)
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