
using BubsyArchipelagoMod.Instances;
using Il2CppFabraz.SaveData;
using MelonLoader;

namespace BubsyArchipelagoMod.Helpers;
public static class LevelUnlockHelper
{
    private static List<string> itemNames = [
        "1-1 Unlock",
        "1-2 Unlock",
        "1-3 Unlock",
        "1-4 Unlock",
        "1-5 Unlock",
        "2-1 Unlock",
        "2-2 Unlock",
        "2-3 Unlock",
        "2-4 Unlock",
        "2-5 Unlock",
        "3-1 Unlock",
        "3-2 Unlock",
        "3-3 Unlock",
        "3-4 Unlock",
        "3-5 Unlock",
        "Tutorial Unlock",
        "Gauntlet Unlock"
    ];
    private static List<string> itemNamesBlackHole = [
        "1-1 BH Unlock",
        "1-2 BH Unlock",
        "1-3 BH Unlock",
        "1-4 BH Unlock",
        "1-5 BH Unlock",
        "2-1 BH Unlock",
        "2-2 BH Unlock",
        "2-3 BH Unlock",
        "2-4 BH Unlock",
        "2-5 BH Unlock",
        "3-1 BH Unlock",
        "3-2 BH Unlock",
        "3-3 BH Unlock",
        "3-4 BH Unlock",
        "3-5 BH Unlock"
    ];

    public static Dictionary<string, string> itemNameToLevelName = new Dictionary<string, string>
    {
        {"1-1 Unlock", "1-1 Woolie Outskirts" },
        {"1-2 Unlock", "1-2 Heartfelt Village" },
        {"1-3 Unlock", "1-3 Fleeceway" },
        {"1-4 Unlock", "1-4 Knitty City" },
        {"1-5 Unlock", "1-5 Baarbee's Skatepark" },
        {"2-1 Unlock", "2-1 Crafty Climb" },
        {"2-2 Unlock", "2-2 Treetop Bonanza" },
        {"2-3 Unlock", "2-3 Glittery Snows" },
        {"2-4 Unlock", "2-4 Cardboard Castles" },
        {"2-5 Unlock", "2-5 Baartholomeo's Keep" },
        {"3-1 Unlock", "3-1 Aqua Trashia" },
        {"3-2 Unlock", "3-2 Big Dam" },
        {"3-3 Unlock", "3-3 Tall Order" },
        {"3-4 Unlock", "3-4 Surging Stock" },
        {"3-5 Unlock", "3-5 Baaptiste's Lab" },
        {"1-1 BH Unlock", "1-1 Woolie Outskirts" },
        {"1-2 BH Unlock", "1-2 Heartfelt Village" },
        {"1-3 BH Unlock", "1-3 Fleeceway" },
        {"1-4 BH Unlock", "1-4 Knitty City" },
        {"1-5 BH Unlock", "1-5 Baarbee's Skatepark" },
        {"2-1 BH Unlock", "2-1 Crafty Climb" },
        {"2-2 BH Unlock", "2-2 Treetop Bonanza" },
        {"2-3 BH Unlock", "2-3 Glittery Snows" },
        {"2-4 BH Unlock", "2-4 Cardboard Castles" },
        {"2-5 BH Unlock", "2-5 Baartholomeo's Keep" },
        {"3-1 BH Unlock", "3-1 Aqua Trashia" },
        {"3-2 BH Unlock", "3-2 Big Dam" },
        {"3-3 BH Unlock", "3-3 Tall Order" },
        {"3-4 BH Unlock", "3-4 Surging Stock" },
        {"3-5 BH Unlock", "3-5 Baaptiste's Lab" },
        {"Tutorial Unlock", "Tutorial" },
        {"Gauntlet Unlock", "Gauntlet" }
    };

    private static Dictionary<string, int> progressiveOffsets = new Dictionary<string, int>
    {
        {"Progressive Wooltopia Unlock", 0 },
        {"Progressive Craftus Unlock", 5 },
        {"Progressive Metallurgia Unlock", 10 },
        {"Progressive Wooltopia BH Unlock", 15 },
        {"Progressive Craftus BH Unlock", 20 },
        {"Progressive Metallurgia BH Unlock", 25 }
    };
    private static SortedSet<string> unlockedNormalLevels = new SortedSet<string>();
    private static SortedSet<string> unlockedBlackHoleLevels = new SortedSet<string>();

    public static bool TryUnlockLevelByItemName(string itemName)
    {
        if (itemNames.Contains(itemName))
        {
            unlockedNormalLevels.Add(itemNameToLevelName[itemName]);
            return true;
        }
        if (itemNamesBlackHole.Contains(itemName))
        {
            unlockedBlackHoleLevels.Add(itemNameToLevelName[itemName]);
            return true;
        }
        if (!progressiveOffsets.TryGetValue(itemName, out int progOffset))
            return false;
        UnlockNextPlanetLevel(progOffset);
        return true;
    }

    private static void UnlockNextPlanetLevel(int offset)
    {
        bool blackHole = false;
        if (offset >= 15)
        {
            offset -= 15;
            blackHole = true;
        }
        if (offset < 0 || offset > 10)
        {
            MelonLogger.Msg(ConsoleColor.Red, $"Offset of {offset + (blackHole ? 15 : 0)} out of range for UnlockNextPlanetLevel");
            return;
        }
        SortedSet<string> unlockSet = blackHole ? unlockedBlackHoleLevels : unlockedNormalLevels;
        for (int i = offset; i < offset + 5; i++)
            if (unlockSet.Add(itemNameToLevelName[itemNames[i]]))
                return;
    }

    public static bool IsSelectedLevelUnlocked()
    {
        string levelName = GalaxyMapInstance.GetCurrentLevelName();
        bool blackHole = SaveDataManager.Instance.CurrentSaveData.blackholeModeActive;
        return IsLevelUnlocked(levelName, blackHole);
    }

    public static bool IsLevelUnlocked(string levelName, bool blackHoleMode = false)
    {
        SortedSet<string> unlocks = blackHoleMode ? unlockedBlackHoleLevels : unlockedNormalLevels;
        return unlocks.Contains(levelName);
    }

    public static string GetUnavailableLevelText(string levelName)
    {
        return $"<color=#FF0000FF> (Locked) {levelName}</color>";
    }

    public static void LockAllLevels()
    {
        unlockedNormalLevels.Clear();
        unlockedBlackHoleLevels.Clear();
    }

    public static void UnlockAllLevels()
    {
        foreach (string name in itemNames)
            unlockedNormalLevels.Add(itemNameToLevelName[name]);
        foreach (string name in itemNamesBlackHole)
            unlockedBlackHoleLevels.Add(itemNameToLevelName[name]);
    }
}
