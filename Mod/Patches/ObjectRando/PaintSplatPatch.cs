using BubsyArchipelagoMod.Helpers;
using BubsyArchipelagoMod.Instances;
using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;

namespace BubsyArchipelagoMod.Patches.ObjectRando;

// Unity Explorer really doesn't like this one for some reason
[HarmonyPatch(typeof(BubsyCharacterController), nameof(BubsyCharacterController.TriggerCameraPaintSplat), [typeof(int)])]
public static class ToxicPaintPatch
{
    public static void Postfix()
    {
        if (!ObjectInventory.NonToxicPaint)
            BubsyInstance.WhyAreYouHittingYourself();
    }
}
