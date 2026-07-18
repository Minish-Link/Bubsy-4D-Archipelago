
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI.Atari;
using MelonLoader;

namespace BubsyArchipelagoMod.Patches.Levels;


[HarmonyPatch(typeof(SaveData), nameof(SaveData.GetLevelBeaten))]
public static class LevelBeatenPatch
{
    public static bool Postfix(bool _result, string id)
    {
        if (id == "Planet1_Level5")
            return true;
        if (id == "Planet2_Level5")
            return true;
        if (id == "Planet3_Level5")
            return true;
        if (id == "Planet3_Level2")
            return true;
        return _result;
    }
}