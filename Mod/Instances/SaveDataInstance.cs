

using Il2CppFabraz.SaveData;

namespace BubsyArchipelagoMod.Instances;

public static class SaveDataInstance
{
    public static SaveData Instance
    {
        get => SaveDataManager.Instance.CurrentSaveData;
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