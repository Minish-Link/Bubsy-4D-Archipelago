using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI.Atari;

namespace BubsyArchipelagoMod.Patches.Shop;
/*
[HarmonyPatch(typeof(SaveData), "totalYarnballsSpent", MethodType.Getter)]
[HarmonyPatch([typeof(int)])]
public static class SpendYarnballsPatch
{
    public static int Postfix()
    {
        Bubsy4DArchi.LogPatchMessage("Get Spent Yarnballs");

        return 0;
    }
}

[HarmonyPatch(typeof(SaveData), "totalBlueprintsSpent", MethodType.Getter)]
[HarmonyPatch([typeof(int)])]
public static class SpendBlueprintPatch
{
    public static int actualBlueprintCost;

    public static int Postfix()
    {
        Bubsy4DArchi.LogPatchMessage(" Get Spent Blueprints");
        return 0;
    }
}
*/