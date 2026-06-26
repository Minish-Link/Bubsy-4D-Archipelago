using BubsyArchipelagoMod.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI.Atari;

namespace BubsyArchipelagoMod.Patches.Shop;

[HarmonyPatch(typeof(GearShopMenu), "PopulateEntries", [typeof(int), typeof(bool)])]
[HarmonyPatch(typeof(GearShopMenu), "PopulateEntries", [typeof(int)])]
public static class GearShopPopulatePatch
{
    public static void Postfix(ref GearShopMenu __instance)
    {
        return;
        // todo
        Bubsy4DArchi.LogPatchMessage("whoooa", LogType.DEFAULT);
        for (int i = 0; i < __instance.currentEntries.Count; i++)
        {
            GearShopEntry entry = __instance.currentEntries[i];
            Bubsy4DArchi.LogPatchMessage(entry.itemData.nameContent);
            if (!VanillaShopHelper.HasSkinOrUpgrade(entry.itemData.nameContent))
            {
                entry.itemData.price = 999999;
                entry.cost.text = entry.itemData.price.ToString();
                entry.label.color = entry.unavailableColor;
                entry.label.text += "(Not Found)";
            }
        }
    }
}