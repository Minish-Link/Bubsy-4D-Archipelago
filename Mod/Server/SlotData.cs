

using MelonLoader;
using Newtonsoft.Json.Linq;

namespace BubsyArchipelagoMod.Server;


public static class SlotData
{
    public static string apworldVersion;
    /// <summary>
    /// Takes in the player's slot data and attempt to load it.
    /// If the slot data loads successfuly, returns 0.
    /// If the version of the mod is higher than the apworld, return 1. If it is lower, return -1
    /// If the slot data fails to load, the player should be disconnected from the server and an error message should be shown.
    /// </summary>
    /// <param name="newSlotData"></param>
    /// <returns></returns>
    public static int LoadSlotData(Dictionary<string, object> newSlotData)
    {
        long compatibleVersion = (long)newSlotData["ModVersion"];
        apworldVersion = (string)newSlotData["ModSemantic"];
        if (compatibleVersion > Core.versionCompatability)
            return 1;
        else if (compatibleVersion < Core.versionCompatability)
            return -1;

        ShuffledYarnballs = (bool)newSlotData["ShuffledYarnballs"];
        ShuffledSilverYarnballs = (bool)newSlotData["ShuffledSilverYarnballs"];
        ShuffledBlueprints = (bool)newSlotData["ShuffledBlueprints"];
        ShuffledGoldenFleece = (bool)newSlotData["ShuffledGoldenFleece"];
        ShuffledVoidFleece = (bool)newSlotData["ShuffledVoidFleece"];
        MelonLogger.Msg("Attempting to load Shop Prices");
        MelonLogger.Msg(newSlotData["ShopPrices"].GetType());
        LoadAllShopPrices((JArray)newSlotData["ShopPrices"]);

        return 0;
    }

    private static void LoadAllShopPrices(JArray shopPriceData)
    {
        MelonLogger.Msg($"Called Load All ShopPrices with {shopPriceData.Count} entries");
        shopPrices.Clear();
        foreach (var entry in shopPriceData.ToArray())
        {
            MelonLogger.Msg("Creating entry");
            var temp = entry.ToObject<Dictionary<string, int>>();
            AddShopPrice(temp["Currency"], temp["Price"]);
            MelonLogger.Msg("Entry Added");
        }

    }

    private static void AddShopPrice(long currencyType, long price)
    {
        string currencyName;
        if (currencyType == 1)
            currencyName = "Yarnball";
        else if (currencyType == 3)
            currencyName = "Blueprint";
        else if (currencyType == 6)
            currencyName = "Void Fleece";
        else
            return;


        shopPrices.Add(Tuple.Create(shopPrices.Count + 1, currencyName, price));
    }

    private static List<Tuple<int, string, long>> shopPrices = new List<Tuple<int, string, long>>();

    public static List<Tuple<int, string, long>> ShopPrices
    {
        get => shopPrices;
    }

    private static bool m_blackHolePairs = false;

    /// <summary>
    /// If true, a black hole level will be unlocked automatically when its normal counterpart is unlocked.
    /// </summary>
    public static bool BlackHolePairs
    {
        get => m_blackHolePairs;
        private set => m_blackHolePairs = value;
    }

    private static bool m_shuffledYarnballs = false;
    private static bool m_shuffledSilverYarnballs = false;
    private static bool m_shuffledBlueprints = false;
    private static bool m_shuffledGoldenFleece = false;
    private static bool m_shuffledVoidFleece = false;

    public static bool ShuffledYarnballs
    {
        get => m_shuffledYarnballs;
        private set => m_shuffledYarnballs = value;
    }
    public static bool ShuffledSilverYarnballs
    {
        get => m_shuffledSilverYarnballs;
        private set => m_shuffledSilverYarnballs = value;
    }
    public static bool ShuffledBlueprints
    {
        get => m_shuffledBlueprints;
        private set => m_shuffledBlueprints = value;
    }
    public static bool ShuffledGoldenFleece
    {
        get => m_shuffledGoldenFleece;
        private set => m_shuffledGoldenFleece = value;
    }
    public static bool ShuffledVoidFleece
    {
        get => m_shuffledVoidFleece;
        private set => m_shuffledVoidFleece = value;
    }

}