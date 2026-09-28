
using BubsyArchipelagoMod.Helpers;
using BubsyArchipelagoMod.Instances;

namespace BubsyArchipelagoMod.Server;

public static class ReceivedItemHandler
{
    private static int receivedItemCount = 0;

    public static void HandleItem(string itemName, int currentIndex)
    {
        if (currentIndex < receivedItemCount)
            return;
        switch (itemName)
        {
            case "What Could Possibly Go Wrong?":
                BubsyInstance.SayTheLineBubsy();
                break;
            default:
                if (LevelUnlockHelper.TryUnlockLevelByItemName(itemName))
                    break;
                if (MoveInventory.TryUnlockMoveByItemName(itemName))
                    break;
                if (ObjectInventory.TryUnlockObjectByItemName(itemName))
                    break;
                break;
        }
        receivedItemCount++;
        
    }
}