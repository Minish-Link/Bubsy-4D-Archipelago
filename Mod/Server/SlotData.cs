

namespace BubsyArchipelagoMod.Server;

public static class SlotData
{
    public static void LoadSlotData() // TODO Insert data argument here
    {
        // TODO
    }

    private static List<Tuple<string, int>> shopPrices = new List<Tuple<string, int>>();

    private static bool m_blackHolePairs = false;

    public static bool BlackHolePairs
    {
        get => m_blackHolePairs;
        private set => m_blackHolePairs = value;
    }

    private static void AddShopPrice(string currencyName, int price)
    {
        if (currencyName != "Yarnball" || currencyName != "Blueprint" || currencyName != "Void Fleece")
            return;
        shopPrices.Add(Tuple.Create(currencyName, price));
    }

}