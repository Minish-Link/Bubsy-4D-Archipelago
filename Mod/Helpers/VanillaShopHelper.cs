using Il2CppFabraz.SaveData;

namespace BubsyArchipelagoMod.Helpers
{
    public static class VanillaShopHelper
    {
        private static Dictionary<string, string> upgradeStateIDs = new Dictionary<string, string>
        {
            {"Twirl Jump", "94f4e171-de2b-49ef-a1d6-d2cfa4c1a8d5" },
            {"Crouch Jump", "5850365b-e111-43e4-ab05-76a823604355" },
            {"Hairball Bouncer", "a026350a-ae60-44a2-9b19-1e671a69dd55" },
            {"Item Sniffer", "f6249582-0432-4829-a439-4aa00862e0fd" },
            {"Wall Claws", "c6080286-1e2a-4d89-b606-6ef14e0f3010" },
            {"10th Life", "d1930b89-70cb-4c8b-a7dd-b9afa1d72e89" },
            {"OG Coyote Time", "239588de-d7d2-4932-87e1-2deb00af4238" },
            {"Scenic Pooper", "402809e3-38f0-41de-a427-f75d655f8457" },
            {"Catnap", "c979360f-1f08-4b1e-b62c-701ffd345b50" },
            {"Zoomie!", "09f4c30d-4fbf-4556-b021-a44f51754b53" },
            {"Hairball Air Slam", "abcb3ba2-1eb8-4bd1-a8a4-0d9a8677eb25" },
            {"Hairball Drift", "f2674183-5362-4bc5-b7ff-ae640af96490" }
        };

        private static Dictionary<string, string> outfitStateIDs = new Dictionary<string, string>
        {
            {"Ol' Reliable", "bb0fa2eb-90b1-475f-9b32-7fbfd33003a5" },
            {"Bubsy 3D", "40ec9a0d-be0f-4cc3-8362-90883a5f20ea" },
            {"Night Jacket", "4db548a4-59e0-4894-926f-88bcba9ebbe0" },
            {"Tiger Jacket", "4ca552d8-c88c-4d5e-99b1-8a7ed16127f9" },
            {"Leather Jacket", "acdf37cb-e8a1-454e-8c45-290091f9b8ac" },
            {"Hedgehog Style", "ba76ef78-0786-42d3-b8f8-b9582f4d72eb" },
            {"VR Mode", "584a2c33-f46f-4ecf-b700-36b71809ddfd" },
            {"Puppet", "c6cafc21-4f4b-4978-8c9f-f983442a7499" },
            {"Gothsby", "20ed33d0-d97d-4c72-bd98-8d8f02ec2271" },
            {"Bublin", "71d4bee2-4797-4071-8244-e4be0c963be1" },
            {"Retro 4D", "094330f5-092c-4f0a-85a0-2866db0dc669" },
            {"Red Robe", "3074c4f3-29a5-4c7f-868c-0b8b24df1eac" },
            {"Undead", "ba73d823-0d06-4c1f-a777-2930e10eb76d" }
        };

        private static Dictionary<string, string> purchasedStateIDs = new Dictionary<string, string>
        {
            {"Twirl Jump", "648e5905-911c-4c08-80d6-c9f40f267e83" },
            {"Crouch Jump", "d0689cb1-e62b-49d9-aa6f-b62c9df8b70c" },
            {"Hairball Bouncer", "f5933273-ec78-477c-87a2-4c7829dbc3ad" },
            {"Item Sniffer", "b11c8b4e-8c41-4ff8-9829-aba219d8ed37" },
            {"Wall Claws", "8fad3fa1-2239-46a7-ba0e-970aa72d60d0" },
            {"10th Life", "610c845d-1a30-41e4-9a84-1eac7d8efe4a" },
            {"OG Coyote Time", "07332e8f-3c65-490a-b589-3e8f6d2a1ce6" },
            {"Scenic Pooper", "8b5ff17d-1388-4d55-b402-d0372090081f" },
            {"Catnap", "42d38d9f-8112-427b-a887-8cf9342e5aca" },
            {"Zoomie!", "8428a52a-ca4f-4425-8742-306974476c17" },
            {"Hairball Air Slam", "0a6a46aa-3985-458c-bdb9-82c24aa7bdd6" },
            {"Hairball Drift", "36d1d552-8eba-4d77-88c6-440d60411c5e" },
            {"Ol' Reliable", "88642943-0d6b-4c69-bceb-5911e9f632d6" },
            {"Bubsy 3D", "d1077f4d-3046-454c-b8ed-566e780d0078" },
            {"Night Jacket", "bea1f258-d338-4157-ae35-7c2105abd563" },
            {"Tiger Jacket", "2ba0e9ab-7e3f-4024-a50b-865b95853af7" },
            {"Leather Jacket", "66ae56f9-2baf-4138-9483-72f1edb3ed09" },
            {"Hedgehog Style", "9002efa6-8409-427b-9181-f6d64296f94d" },
            {"VR Mode", "d7dd3539-d7a6-4f4e-a7f5-17ee1b107741" },
            {"Puppet", "887e0698-9d27-43eb-839a-85287def17db" },
            {"Gothsby", "41d3ed3d-db23-47d2-b3ee-46d066ae773a" },
            {"Bublin", "6473cb4b-8473-4f5d-8cbf-708ee7d74c7c" },
            {"Retro 4D", "8a7f9f23-cc9d-4519-b400-3d496078f909" },
            {"Red Robe", "c80224ef-eeb6-4a9e-80e7-e115007c0688" },
            {"Undead", "61cedc0b-c196-4d79-b7d1-52fc42651d69" }
        };


        public static bool TryUnlockUpgradeOrOutfit(string itemName)
        {
            string purchaseID;
            if (!purchasedStateIDs.TryGetValue(itemName, out purchaseID))
                return false;
            SaveDataManager.Instance.CurrentSaveData.SetWorldState(purchaseID, true);
            string upgradeID;
            if (upgradeStateIDs.TryGetValue(itemName, out upgradeID))
                SaveDataManager.Instance.CurrentSaveData.SetWorldState(upgradeID, true);
            // TODO Change Bubsy's outfit if the item is an outfit
            return true;
        }

        public static bool IsUpgradeOrOutfitUnlocked(string itemName)
        {
            if (!SaveDataManager.Instance.CurrentSaveData)
                return false;
            string purchaseID;
            if (!purchasedStateIDs.TryGetValue(itemName, out purchaseID))
                return false;
            bool unlocked;
            SaveDataManager.Instance.CurrentSaveData.TryGetWorldState(purchaseID, out unlocked);
            return unlocked;
        }

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
