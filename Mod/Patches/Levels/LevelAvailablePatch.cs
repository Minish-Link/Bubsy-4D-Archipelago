
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
        return true;
        //return _result;
    }
}