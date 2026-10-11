
namespace BubsyArchipelagoMod.Helpers;

public static class GoalHelper
{
    public enum GoalType
    {
        Invalid = 0,
        Baaptiste = 1,
        Baabosses = 2,
        GoldenFleece = 3,
        VoidFleece = 4,
        AllFleece = 5,
        NormalLevels = 6,
        BlackHoleLevels = 7,
        AllLevels = 8
    }

    private static GoalType currentGoalType = GoalType.Invalid;
    private static bool gauntletRequired = false;



    public static bool CheckForGoal()
    {
        bool goalReqMet = false;

        switch (currentGoalType)
        {
            case GoalType.Baaptiste:
                break;
            case GoalType.Baabosses:
                break;
            case GoalType.GoldenFleece:
                break;
            case GoalType.VoidFleece:
                break;
            case GoalType.AllFleece:
                break;
            case GoalType.NormalLevels:
                break;
            case GoalType.BlackHoleLevels:
                break;
            case GoalType.AllLevels:
                break;
            default:
                break;
        }

        if (!goalReqMet)
            return false;
        // TODO
        return false;

    }
}