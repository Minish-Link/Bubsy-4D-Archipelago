using BubsyArchipelagoMod.Server;

namespace BubsyArchipelagoMod.Patches.Shop;
public static class ShopInventory
{
    struct ShopItemData
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
}
