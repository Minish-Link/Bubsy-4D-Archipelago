using BubsyArchipelagoMod.Server;
using Harmony;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.TextSystem;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Helpers;
public static class ShopHelper
{
    private static GearShopMenu currentMenu;
    private static bool menuIsOpen = false;
    private static GearShopEntry currentEntry;
    private static bool isInitialized = false;

    private static CollectableType yarnCurrency;
    private static CollectableType blueprintCurrency;
    private static CollectableType voidCurrency;

    public static List<ItemData> currentItemDatas = new List<ItemData>();
    public static bool overrideEntries = true;

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

    public static void InitializeAPItemData(ref GearShopMenu templates)
    {
        if (isInitialized)
            return;

        SaveDataManager.Instance.CurrentSaveData.SetWorldState("648e5905-911c-4c08-80d6-c9f40f267e83", true);
        SaveDataManager.Instance.CurrentSaveData.SetWorldState("2ba0e9ab-7e3f-4024-a50b-865b95853af7", true);
        SaveDataManager.Instance.CurrentSaveData.SetWorldState("8a7f9f23-cc9d-4519-b400-3d496078f909", true);
        SaveDataManager.Instance.CurrentSaveData.SetWorldState("610c845d-1a30-41e4-9a84-1eac7d8efe4a", true);

        yarnCurrency = templates.currencyTypeYarnball;
        blueprintCurrency = templates.currencyTypeBlueprint;
        voidCurrency = templates.outfitsData[10].currencyType;

        currentItemDatas.Clear();
        for (int i = 0; i < 8; i++)
        {
            ItemData newData = new ItemData();
            newData.price = i * 50;
            newData.currencyType = yarnCurrency;
            newData.descriptionContent = $"Test Description {i}";
            newData.nameContent = $"Test Name {i}";
            newData.nameContentLocalisation = new TranslationLine();
            newData.descriptionContentLocalisation = new TranslationLine();
            currentItemDatas.Add(newData);
        }
        for (int i = 0; i < 12; i++)
        {
            ItemData newData = new ItemData();
            newData.price = i + 1;
            newData.currencyType = blueprintCurrency;
            newData.descriptionContent = $"Blueprint Description {i}";
            newData.nameContent = $"Blueprint Name {i}";
            newData.nameContentLocalisation = new TranslationLine();
            newData.descriptionContentLocalisation = new TranslationLine();
            currentItemDatas.Add(newData);
        }
        for (int i = 0; i < 5 ; i++)
        {
            ItemData newData = new ItemData();
            newData.price = (i+1)*3;
            newData.currencyType = voidCurrency;
            newData.descriptionContent = $"Void Description {i}";
            newData.nameContent = $"Void Name {i}";
            newData.nameContentLocalisation = new TranslationLine();
            newData.descriptionContentLocalisation = new TranslationLine();
            currentItemDatas.Add(newData);
        }
        isInitialized = true;
    }

    public static void OnAPEntryClicked()
    {
        if (!currentEntry)
        {
            return;
        }
        bool purchased = false;

        if (currentEntry.getItemData.currencyType == yarnCurrency)
            purchased = currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalYarnballCount;
        else if (currentEntry.getItemData.currencyType == blueprintCurrency)
            purchased = currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalBlueprintsCount;
        else if (currentEntry.getItemData.currencyType == voidCurrency)
            purchased = currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalVoidFleeceCount;

        if (purchased)
        {
            // TODO Connect to function that sends checks to the server.
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
