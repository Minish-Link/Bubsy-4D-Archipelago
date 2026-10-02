using HarmonyLib;
using Il2CppFabraz.PlayerCharacter.Bubsy;
using MelonLoader;
using Il2CppFabraz.Audio;
using Il2CppFabraz;
using Il2CppFabraz.Interactables;
using Il2CppFabraz.PlayerCharacter;
using Archipelago.MultiClient.Net.Packets;

namespace BubsyArchipelagoMod.Instances;

[HarmonyPatch(typeof(BubsyCharacterController), nameof(BubsyCharacterController.Start))]
public static class BubsyInstance
{
    public static BubsyCharacterController Instance;

    public static void Postfix(BubsyCharacterController __instance)
    {
        //MelonLogger.Msg(ConsoleColor.Green, "Bubsy has awoken");
        Instance = __instance;
    }

    public static void SayTheLineBubsy()
    {
        Instance?.vo.voPlaySound.Play("whatcouldpossiblygowrong", PlaySound.PlayType.Random);
        Core.session?.Socket.SendPacket(new SayPacket() { Text = "What Could Possibly Go Wrong?" });
    }

    public static void WhyAreYouHittingYourself(bool ignoreInvincibility = false)
    {
        if (!Instance)
            return;
        IDamage damage = Instance.GetComponent<IDamage>();
        Damageable health = Instance.life.health;

        if (damage == null || !health)
            return;

        if ((health.invincibilityActive && !ignoreInvincibility) || health.currentHealth <= 0)
            return;

        health.TakeDamage(damage, UnityEngine.Vector3.up);
        if (!ignoreInvincibility)
            health.TriggerInvincibility(1.0f);
    }

    public static void KillHim()
    {
        for (int i = 0; i < 4; i++)
        {
            WhyAreYouHittingYourself(true);
        }
    }
}