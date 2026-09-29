using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;
using Il2CppFabraz.Audio;
using Il2CppFabraz;
using Il2CppFabraz.Interactables;
using Il2CppFabraz.PlayerCharacter;
using System.Numerics;

namespace BubsyArchipelagoMod.Instances;

[HarmonyPatch(typeof(BubsyCharacterController), nameof(BubsyCharacterController.Start))]
public static class BubsyInstance
{
    public static BubsyCharacterController Instance;

    public static void Postfix(BubsyCharacterController __instance)
    {
        MelonLogger.Msg(ConsoleColor.Green, "Bubsy has awoken");
        Instance = __instance;
    }

    public static void SayTheLineBubsy()
    {
        if (!Instance)
            return;
        Instance.vo.voPlaySound.Play("whatcouldpossiblygowrong", PlaySound.PlayType.Random);
    }

    public static void WhyAreYouHittingYourself()
    {
        if (!Instance)
            return;
        IDamage damage = Instance.GetComponent<IDamage>();
        Damageable health = Instance.life.health;

        if (damage == null || !health)
            return;

        if (health.invincibilityActive || health.currentHealth <= 0)
            return;

        health.TakeDamage(damage, UnityEngine.Vector3.up);
        health.TriggerInvincibility(1.0f);
    }
}