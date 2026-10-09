using BubsyArchipelagoMod.Instances;
using BubsyArchipelagoMod.ModGUI;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppFabraz.UI.Atari;
using MelonLoader;
using UnityEngine;

namespace BubsyArchipelagoMod.Patches.Menus;


[HarmonyPatch(typeof(TitleMenu), nameof(TitleMenu.ShowMenu))]
public static class TitleMenuPatch
{
    public static TitleMenu Instance;

    static void Postfix(TitleMenu __instance)
    {
        Instance = __instance;

        if (Core.isDebug)
            MelonLogger.Msg("Show Title Menu");
        Transform saveSlotsRoot = __instance.gameObject.transform.FindChild("Save Slots");
        if (!saveSlotsRoot)
            return;
        for (int i = 1; i <= 3; i++)
        {
            Transform saveSlot = saveSlotsRoot.FindChild($"Save Slot {i}");
            if (!saveSlot)
                continue;
            if (Core.isDebug)
                MelonLogger.Msg($"Destroying {saveSlot.gameObject.name}");
            saveSlot.gameObject.SetActive(false);
            MelonLogger.Msg(saveSlotsRoot.position);
        }

        APGUI.Initialize(saveSlotsRoot.position);
    }

    public static void LoadAPSaveFile()
    {
        if (!Instance)
            return;
        Instance.OnTriggerSlot(3);
        SaveDataInstance.InitializeAPSaveState();
        SaveDataInstance.ResetCollectableCounts();
        //Instance.LoadTargetSlot(3, false);
    }
}

[HarmonyPatch(typeof(TitleMenu), nameof(TitleMenu.HideMenu))]
public static class HideMainMenuPatch
{
    static void Postfix()
    {
        APGUI.StopDisplay();
    }
}