
using BubsyArchipelagoMod.Instances;
using Il2CppFabraz.Interactables;
using MelonLoader;
using System.Collections;
using Unity.Collections;
using UnityEngine;

namespace BubsyArchipelagoMod.Helpers;

public static class BubsyDeathLink
{
    private static bool deathLinkEnabled = false;
    private static bool canReceiveDeath = true;
    private static bool canSendDeath = true;
    private static System.Random rng = new System.Random();

    
    public static void SetDeathLinkEnabled(bool enabled)
    {
        deathLinkEnabled = enabled;
    }

    public static void TrySendDeathLink(IDamage damageSource)
    {
        DamageSourceType deathType;
        if (damageSource is null)
            deathType = DamageSourceType.Force;
        else
            deathType = damageSource.DamageType;
        TrySendDeathLink(deathType);
    }

    public static void TrySendDeathLink(DamageSourceType damageType)
    {
        if (!deathLinkEnabled || !canSendDeath)
            return;

        MelonCoroutines.Start(DeathLinkSendCooldown());

    }

    private static string GetDeathLinkMessage(DamageSourceType damageType)
    {
        string playerName = Core.session.Players.ActivePlayer.Alias;
        if (!deathLinkMessages.TryGetValue(damageType, out List<string> choices) || choices.Count == 0)
            return $"{playerName} died of mysterious causes.";
        return string.Format(choices[rng.Next(0, choices.Count - 1)], playerName);
    }

    private static Dictionary<DamageSourceType, List<string>> deathLinkMessages = new()
    {
        {DamageSourceType.Cutting, [

            ] },
        {DamageSourceType.Energy,[

            ] },
        {DamageSourceType.Fall, [

            ] },
        {DamageSourceType.Flattening, [

            ] },
        {DamageSourceType.Force, [

            ] },
        {DamageSourceType.Piercing, [

            ] },
        {DamageSourceType.Player, [
            "{0} Died."
            ] },
        {DamageSourceType.Projectile, [

            ] },
        {DamageSourceType.Water, [

            ] }
    };

    public static void TryReceiveDeathLink()
    {
        if (!deathLinkEnabled || !canReceiveDeath)
            return;

        MelonCoroutines.Start(DeathLinkReceiveCooldown());
        BubsyInstance.KillHim();
    }

    private static IEnumerator DeathLinkSendCooldown()
    {
        canSendDeath = false;
        yield return new WaitForSeconds(10.0f);
        canSendDeath = true;
    }

    private static IEnumerator DeathLinkReceiveCooldown()
    {
        canReceiveDeath = false;
        yield return new WaitForSeconds(10.0f);
        canReceiveDeath = true;
    }
}
