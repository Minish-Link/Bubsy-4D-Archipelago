using BubsyArchipelagoMod.Server;
using Il2CppFabraz;

namespace BubsyArchipelagoMod.Helpers;
public static class ShopInventory
{
    public struct ShopItemData
    {
        public int YarnCost { get; private set; }
        public int BlueprintCost { get; private set; }

        public LocationData ShopLocation;
        public bool IsPurchased;

        public int GetCurrentYarnCost()
        {
            // TODO Get Total Yarnballs Spent and subtract from YarnCost (Clamped 
            return YarnCost;
        }

        public bool TryPurchase()
        {
            // TODO Reduce Yarnballs and Increase Total Yarnballs Spent
            // TODO Send Location
            // TODO Refuse if Bubsy does not have enough yarn.
            return false;
        }
    }

    public static ItemData GetItemData(ShopItemData apData)
    {
        ItemData newData = new ItemData();
        newData.nameContent = apData.ShopLocation.ItemName;

        return newData;
    }
}
