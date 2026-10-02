

using Il2CppFabraz.SaveData;
using MelonLoader;

namespace BubsyArchipelagoMod.Instances;

public static class SaveDataInstance
{
    public static SaveData Instance
    {
        get => SaveDataManager.Instance.CurrentSaveData;
    }

    public static bool SetWorldState(string id, bool state)
    {
        if (!Instance)
        {
            MelonLogger.Msg("Couldn't set world state, Save Data Instance not found");
            return false;
        }
        Instance.SetWorldState(id, state);
        return true;
    }

    public static void ResetCollectableCounts()
    {
        if (!Instance)
            return;
        Instance.CurrentYarnballCount = 0;
        Instance.CurrentBlueprintCount = 0;
        Instance.CurrentGoldenFleeceCount = 0;
        Instance.CurrentVoidFleeceCount = 0;
    }

    public static void AddYarnballs(int count = 1)
    {
        if (!Instance)
            return;
        Instance.CurrentYarnballCount += count;
    }

    public static void AddBlueprint()
    {
        if (!Instance)
            return;
        Instance.CurrentBlueprintCount += 1;
    }

    public static void AddVoidFleece()
    {
        if (!Instance)
            return;
        Instance.CurrentVoidFleeceCount += 1;
    }

    public static void AddGoldenFleece()
    {
        if (!Instance)
            return;
        Instance.CurrentGoldenFleeceCount += 1;
    }
}