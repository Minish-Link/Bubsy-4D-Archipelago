using Il2CppFabraz;
using Il2CppFabraz.Interactables;
using Il2CppFabraz.PlayerCharacter;
using UnityEngine;

namespace BubsyArchipelagoMod.Helpers;

public static class ObjectDisabler
{
    public static void TryDisableObjects(string unusedSceneName)
    {
        // Wouldn't it be funny if we had level-specific objectsanity
        if (!ObjectInventory.Pinheads)
            TryDisablePinheads();
        if (true)
            TryDisableRedBubbles();
        if (true)
            TryDisableBlueBubbles();
    }

    private static void TryDisablePinheads()
    {
        if (!ObjectInventory.Pinheads)
        {
            var targets = Resources.FindObjectsOfTypeAll<CharacterAttackTarget>();
            foreach (CharacterAttackTarget target in targets)
            {
                // TODO separate the pins from the other objects
                string targetName = target.gameObject.transform.parent.gameObject.name;
                if (targetName.Length >= 10 && targetName.Substring(0, 10) == "Pounce Pin")
                {
                    pinHeadObjects.Append(target);
                    target.active = false;
                }
            }
        }
    }

    public static void TryEnablePinheads()
    {
        foreach (CharacterAttackTarget target in pinHeadObjects)
            target.active = true;
        pinHeadObjects.Clear();
    }

    private static void TryDisableRedBubbles()
    {
        var bubbles = Resources.FindObjectsOfTypeAll<SpeedBurst>();
        foreach (SpeedBurst bubble in bubbles)
        {
            bubble.gameObject.active = false;
            redBubbleObjects.Append(bubble);
        }
    }

    public static void TryEnableRedBubbles()
    {
        foreach (SpeedBurst bubble in redBubbleObjects)
            bubble.gameObject.active = true;
        redBubbleObjects.Clear();
    }

    private static void TryDisableBlueBubbles()
    {
        var bubbles = Resources.FindObjectsOfTypeAll<ForceBounce>();
        foreach (ForceBounce bubble in bubbles)
        {
            bubble.gameObject.active = false;
            blueBubbleObjects.Append(bubble);
        }
    }

    public static void TryEnableBlueBubbles()
    {
        foreach (ForceBounce bubble in blueBubbleObjects)
            bubble.gameObject.active = true;
        blueBubbleObjects.Clear();
    }

    public static void ClearObjects()
    {
        pinHeadObjects.Clear();
    }

    public static void TryEnableObjectType(string objectName)
    {
        switch (objectName)
        {
            case "Pinheads":
                TryEnablePinheads();
                break;
            case "Red Bubbles":
                TryEnableRedBubbles();
                break;
            case "Blue Bubbles":
                TryEnableBlueBubbles();
                break;
            default:
                break;
        }
    }

    private static List<CharacterAttackTarget> pinHeadObjects = new List<CharacterAttackTarget>();
    private static List<SpeedBurst> redBubbleObjects = new List<SpeedBurst>();
    private static List<ForceBounce> blueBubbleObjects = new List<ForceBounce>();
    // Tape Measures
    // Cat Toys
}
