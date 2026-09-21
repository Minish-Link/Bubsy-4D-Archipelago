
using UnityEngine;
namespace BubsyArchipelagoMod.Helpers;

public static class APTextColor
{
    private static Color filler = Color.cyan;
    private static Color progression = Color.mediumPurple;
    private static Color useful = Color.cornflowerBlue;
    private static Color progressionUseful = Color.gold;
    private static Color trap = Color.red;

    private static Color playerColor = Color.lightYellow;
    private static Color selfColor = Color.magenta;
    
    public static Color getItemColor(int itemFlags)
    {
        if ((itemFlags & 1) != 0)
        {
            if ((itemFlags & 2) != 0)
                return progressionUseful;
            else
                return progression;
        }
        else if ((itemFlags & 4) != 0)
            return trap;
        else if ((itemFlags & 2) != 0)
            return useful;

        return filler;
    }

    public static Color getPlayerColor(int playerSlot)
    {
        // TODO
        return playerColor;
    }
}