using HarmonyLib;
using Il2CppFabraz.Audio;
using Il2CppFabraz.UI.Atari;
using MelonLoader;
using static Il2CppFabraz.PlayerCharacter.BaseCharacterController;

namespace BubsyArchipelagoMod.Instances;

[HarmonyPatch(typeof(GearShopMenu), nameof(GearShopMenu.Awake))]
public static class ShopInstance
{
    public static GearShopMenu Instance;
    public static bool currencyTypesLoaded = false;

    public static void Postfix(GearShopMenu __instance)
    {
        Instance = __instance;
        currencyTypesLoaded = false;
        MelonLogger.Msg(ConsoleColor.Green, "Shop's Open");
    }

    public static void PlayVO(bool localItem = true)
    {
        if (!Instance)
            return;
        if (localItem)
            Instance.vo.Play("Buy Clothes", PlaySound.PlayType.Random);
        else
            Instance.vo.Play("Preview Upgrades", PlaySound.PlayType.Random);
    }

    public static bool TryRemoveEntry(ref GearShopEntry entry)
    {
        if (!Instance)
            return false;
        int index = Instance.currentEntries.FindIndex((Il2CppSystem.Predicate<GearShopEntry>)entry.Equals);
        if (index < 0)
        {
            MelonLogger.Msg("Couldn't remove shop entry");
            return false;
        }
        MelonLogger.Msg($"Purchased Item {entry.label.text}");
        UnityEngine.Object.Destroy(entry.gameObject);
        Instance.currentEntries.RemoveAt(index);
        return true;
    }

}
