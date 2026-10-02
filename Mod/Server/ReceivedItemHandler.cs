
using BubsyArchipelagoMod.Helpers;
using BubsyArchipelagoMod.Instances;
using MelonLoader;

namespace BubsyArchipelagoMod.Server;

public static class ReceivedItemHandler
{
    private static int receivedItemCount = 0;
    private static Queue<string> itemQueue = new Queue<string>();


    public static void QueueItem(string itemName)
    {
        MelonLogger.Msg($"Queueing {itemName}");
        itemQueue.Enqueue(itemName);
        //itemQueue.Append(itemName);
    }

    public static void HandleNextItem()
    {
        if (itemQueue.Count == 0)
            return;
        //MelonLogger.Msg("Handling next item");
        HandleItem(itemQueue.Dequeue());
    }

    public static void HandleItem(string itemName)
    {
        switch (itemName)
        {
            case "What Could Possibly Go Wrong?":
                BubsyInstance.SayTheLineBubsy();
                break;
            case "Yarnball":
                SaveDataInstance.AddYarnballs(1);
                break;
            case "Silver Yarnball":
                SaveDataInstance.AddYarnballs(10);
                break;
            case "Blueprint":
                SaveDataInstance.AddBlueprint();
                break;
            case "Golden Fleece":
                SaveDataInstance.AddGoldenFleece();
                break;
            case "Void Fleece":
                SaveDataInstance.AddVoidFleece();
                break;
            default:
                if (LevelUnlockHelper.TryUnlockLevelByItemName(itemName))
                    break;
                if (MoveInventory.TryUnlockMoveByItemName(itemName))
                    break;
                if (ObjectInventory.TryUnlockObjectByItemName(itemName))
                    break;
                if (VanillaShopHelper.TryUnlockUpgradeOrOutfit(itemName))
                    break;
                MelonLogger.Msg(ConsoleColor.Yellow, $"Could not handle item with name {itemName}");
                break;
        }
        receivedItemCount++;
        //MelonLogger.Msg($"Received {receivedItemCount} items so far");
    }
}