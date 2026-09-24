using Il2CppFabraz.PlayerCharacter.Bubsy;
using HarmonyLib;
using MelonLoader;
using Il2CppFabraz.Settings;
using BubsyArchipelagoMod.Helpers;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(SettingsSaveData),nameof(SettingsSaveData.AdjustSetting), [typeof(string), typeof(bool), typeof(bool), typeof(bool)])]
public static class TankControlsPatch
{
    public static void Prefix(string settingID, ref bool value, bool defaultValue, bool triggerEvent)
    {
        if (settingID == "81b09809-6bf4-4dce-a53d-0c7348fc27c6")
        {
            value = value || !MoveInventory.TankControls;
        }
        //MelonLogger.Msg($"{settingID} {value} {defaultValue} {triggerEvent}");
    }
}