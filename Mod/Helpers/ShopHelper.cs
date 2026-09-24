using BubsyArchipelagoMod.Instances;
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
    private static GearShopEntry currentEntry;
    private static bool isInitialized = false;

    private static CollectableType yarnCurrency;
    private static CollectableType blueprintCurrency;
    private static CollectableType voidCurrency;

    public static List<ItemData> currentItemDatas = new List<ItemData>();
    public static bool overrideEntries = true;

    public static void InitializeAPItemData(GearShopMenu templates)
    {
        if (isInitialized)
            return;

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
            int index = ShopInstance.Instance.currentEntries.FindIndex((Il2CppSystem.Predicate<GearShopEntry>)currentEntry.Equals);
            if (index < 0)
                return;
            MelonLogger.Msg($"Purchased Item {currentEntry.label.text}");
            UnityEngine.Object.Destroy(ShopInstance.Instance.currentEntries[index].gameObject);
            ShopInstance.Instance.currentEntries.RemoveAt(index);
        }
    }

    public static void OnAPEntrySelected(GearShopEntry selectedEntry)
    {
        currentEntry = selectedEntry;
    }
}
