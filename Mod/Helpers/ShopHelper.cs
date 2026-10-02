using BubsyArchipelagoMod.Components;
using BubsyArchipelagoMod.Instances;
using BubsyArchipelagoMod.Server;
using Harmony;
using Il2CppFabraz;
using Il2CppFabraz.Audio;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.TextSystem;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Helpers;
public static class ShopHelper
{
    private static GearShopEntry currentEntry;
    private static bool isInitialized = false;

    private static Dictionary<string, CollectableType> currencies = new Dictionary<string, CollectableType>();

    public static List<ItemData> currentItemDatas = new List<ItemData>();
    public static bool overrideEntries = true;

    public static void InitializeAPItemData(GearShopMenu templates)
    {
        if (!ShopInstance.currencyTypesLoaded)
        {
            currencies["Yarnball"] = templates.currencyTypeYarnball;
            currencies["Blueprint"] = templates.currencyTypeBlueprint;
            currencies["Void Fleece"] = templates.outfitsData[10].currencyType;
        }
        if (isInitialized)
            return;
        currentItemDatas.Clear();
        foreach (var shopPrice in SlotData.ShopPrices)
        {
            MelonLogger.Msg($"shopProce: {shopPrice}");
            MelonLogger.Msg(shopPrice);
            ItemData newData = new ItemData();
            newData.price = (int)shopPrice.Item3;
            newData.currencyType = currencies[shopPrice.Item2];
            //if (Core.ScoutedItems == null)
            {
                newData.descriptionContent = "Item Description";
                newData.descriptionContentLocalisation = new TranslationLine();
                newData.nameContent = "Item Name";
                newData.nameContentLocalisation = new TranslationLine();
                currentItemDatas.Add(newData);
            }
        }
        isInitialized = true;
    }

    public static void OnAPEntryClicked()
    {
        if (!currentEntry)
            return;

        bool purchased = false;
        if (currentEntry.getItemData.currencyType == currencies["Yarnball"])
            purchased = currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalYarnballCount;
        else if (currentEntry.getItemData.currencyType == currencies["Blueprint"])
            purchased = currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalBlueprintsCount;
        else if (currentEntry.getItemData.currencyType == currencies["Void Fleece"])
            purchased = currentEntry.getItemData.price <= SaveDataManager.Instance.CurrentSaveData.TotalVoidFleeceCount;

        if (purchased)
        {
            ShopEntryData entryData = currentEntry.GetComponent<ShopEntryData>();
            if (entryData && Core.session != null)
            {
                Core.SendLocationIDs(entryData.LocationID);
            }
            if (ShopInstance.TryRemoveEntry(ref currentEntry))
            {
                ShopInstance.PlayVO();
                MelonLogger.Msg($"Purchased Item {currentEntry.label.text}");
            }
        }
    }

    public static void OnAPEntrySelected(GearShopEntry selectedEntry)
    {
        currentEntry = selectedEntry;
    }

    public static string GetProgressionDisplayText(int itemFlags)
    {
        if ((itemFlags & 4) != 0)
            return "Probably shouldn't buy this one... Eh, what could possibly go wrong?";

        return "I have no idea what this is.";
    }

    //private static Dictionary<string, string> bubsy4DItemDescriptions = new Dictionary<string, string>
    //{
    //    {"Twirl Jump", "Spin in place then jump to trigger a twirl jump." },
    //    {"Crouch Jump", "Crouch then Jump! Do it stationary or while running." },
    //    {"Hairball Bouncer", "Continually bounce in hairball form to increase jump height up to a point." },
    //    {"Item Sniffer", "Sniff out the closest collectable for a hint!" },
    //    {"Wall Claws", "No longer slide down walls, take your time for where to go next." },
    //    {"10th Life", "Gain an extra hit before resetting back to your last checkpoint." },
    //    {"OG Coyote Time", "Walk for a few steps before falling when mooving off a ledge. Looking down optional." },
    //    {"Scenic Pooper", "Teleport between activated checkpoints. Great for the explorer at heart." },
    //    {"Catnap", "Curl up at rest spots to fully regain your health!" },
    //    {"Zoomie!", "Crouch then zoom! Hurdle forward at high speeds." },
    //    {"Hairball Air Slam", "While in hairball form, brake in the air to quickly slam down." },
    //    {"Hairball Drift", "While in hairball form, hold both brake and boost to drift." },
    //    {"Ol' Reliable", "The classic look. Fits like a glove, if the glove was a shirt." },
    //    {"Bubsy 3D", "Less polygons means more aerodynamic platforming." },
    //    {"Night Jacket", "Go for the sleek look perfect for picking up yarnballs at the club." },
    //    {"Tiger Jacket", "Glow like the sunset with this stunning jacket." },
    //    {"Leather Jacket", "Is that leather? From what animal Bubsy?!" },
    //    {"Hedgehog Style", "Ditch the jacket and put on some kicks. Time to go fast!" },
    //    {"VR Mode", "We're all living in a simulation, man." },
    //    {"Puppet", "I... I don't like any of this." },
    //    {"Gothsby", "This is Terrie's favorite outfit, niece approved!" },
    //    {"Bublin", "Do not feed him after midnight." },
    //    {"Retro 4D", "It's like Bubsy 3D but now it's 4D." },
    //    {"Red Robe", "Robed, relaxed, and ready to blow some bubbles." },
    //    {"Undead", "Bubsy's no stranger to dying but he always comes back." },
    //    {"Yarnball", "" },
    //    {"Silver Yarnball", "" },
    //    {"Blueprint", "" },
    //    {"Void Fleece", "" },
    //    {"Golden Fleece", "" }
    //};
}
