namespace BubsyArchipelagoMod.Helpers
{
    public static class VanillaShopHelper
    {
        private static List<string> skinAndUpgradeNames = [
            "Twirl Jump",
            "Crouch Jump",
            "Hairball Bouncer",
            "Item Sniffer",
            "Wall Claws",
            "10th Life",
            "OG Coyote Time",
            "Scenic Pooper",
            "Catnap",
            "Zoomie!",
            "Hairball Air Slam",
            "Hairball Drift",
            "Ol' Reliable",
            "Bubsy 3D",
            "Night Jacket",
            "Tiger Jacket",
            "Leather Jacket",
            "Hedgehog Style",
            "VR Mode",
            "Puppet"
        ];

        private static List<string> collectedItems = [];
        public static bool HasSkinOrUpgrade(string itemName)
        {
            return collectedItems.Contains(itemName);
        }

        public static void AddSkinOrUpgradeToInventory(string itemName)
        {
            if (!collectedItems.Contains(itemName))
            {
                collectedItems.Add(itemName);
            }
        }

        public static void RemoveItemFromInventory(string itemName)
        {
            collectedItems.Remove(itemName);
        }
    }
}
