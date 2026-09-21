using BubsyArchipelagoMod.Server;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Helpers;
public static class ShopHelper
{
    private static GearShopMenu currentMenu;
    private static bool menuIsOpen = false;
    private static GearShopEntry currentEntry;

    private static CollectableType yarnCurrency;
    private static CollectableType blueprintCurrency;
    private static CollectableType voidCurrency;

    public static List<ItemData> currentItemDatas = new List<ItemData>();

    public static void OpenMenu(ref GearShopMenu newMenu)
    {
        currentMenu = newMenu;
        menuIsOpen = currentMenu != null;
    }

    public static void CloseMenu()
    {
        currentMenu = null;
        menuIsOpen = false;
    }

    public static void InitializeAPItemData(GearShopMenu templates)
    {
        yarnCurrency = templates.currencyTypeYarnball;
        blueprintCurrency = templates.currencyTypeBlueprint;
        voidCurrency = templates.outfitsData[10].currencyType;
        // TODO
        currentItemDatas.Clear();
        for (int i = 0; i < 10; i++)
        {
            ItemData newData = new ItemData();
            newData.price = i * 30;
            newData.currencyType = yarnCurrency;
            newData.descriptionContent = $"Test Description {i}";
            newData.nameContent = $"Test Name {i}";
            currentItemDatas.Add(newData);
        }
    }

    public static void OnAPEntryClicked()
    {
        if (!currentEntry)
        {
            return;
        }
        // TODO
        MelonLogger.Msg(currentEntry.getItemData.price);
        if (currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalYarnballCount)
        {
            int index = currentMenu.currentEntries.FindIndex((Il2CppSystem.Predicate<GearShopEntry>)currentEntry.Equals);
            if (index < 0)
                return;
            MelonLogger.Msg($"Purchased Item {currentEntry.label.text}");
            UnityEngine.Object.Destroy(currentMenu.currentEntries[index].gameObject);
            currentMenu.currentEntries.RemoveAt(index);
            
        }
    }

    public static void OnAPEntrySelected(GearShopEntry selectedEntry)
    {
        currentEntry = selectedEntry;
    }
}
