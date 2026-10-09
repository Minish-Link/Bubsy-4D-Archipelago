

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

    public static void UpdateCollectableCounts()
    {
        if (!Instance)
            return;
        if (Yarnballs != m_yarnballsReceived)
            Yarnballs = m_yarnballsReceived;
        if (Blueprints != m_blueprintsReceived)
            Blueprints = m_blueprintsReceived;
        if (VoidFleece != m_voidFleeceReceived)
            VoidFleece = m_voidFleeceReceived;
        if (GoldenFleece != m_goldenFleeceReceived)
            GoldenFleece = m_goldenFleeceReceived;
    }

    private static int m_yarnballsReceived = 0;
    private static int m_blueprintsReceived = 0;
    private static int m_voidFleeceReceived = 0;
    private static int m_goldenFleeceReceived = 0;

    public static int Yarnballs
    {
        get => Instance ? Instance.CurrentYarnballCount : 0;
        private set => Instance.CurrentYarnballCount = value;
    }
    public static int Blueprints
    {
        get => Instance ? Instance.CurrentBlueprintCount : 0;
        private set => Instance.CurrentBlueprintCount = value;
    }
    public static int VoidFleece
    {
        get => Instance ? Instance.CurrentVoidFleeceCount : 0;
        private set => Instance.CurrentVoidFleeceCount = value;
    }
    public static int GoldenFleece
    {
        get => Instance ? Instance.CurrentGoldenFleeceCount : 0;
        private set => Instance.CurrentGoldenFleeceCount = value;
    }

    public static void AddYarnballs(int count = 1)
    {
        m_yarnballsReceived += count;
    }

    public static void AddBlueprint()
    {
        m_blueprintsReceived += 1;
    }

    public static void AddVoidFleece()
    {
        m_voidFleeceReceived += 1;
    }

    public static void AddGoldenFleece()
    {
        m_goldenFleeceReceived += 1;
    }

    public static void InitializeAPSaveState()
    {
        if (SaveDataManager.Instance.currentSaveDataSlot < 3)
            return;
        if (!Instance)
            return;
        if (Instance.TryGetWorldState(Core.GetSaveFileIdentifier(), out bool _))
            return;

        Instance.worldState.Clear();

        Instance.SetWorldState(Core.GetSaveFileIdentifier(), true);
        Instance.SetWorldState("6f376261-3fec-41d5-9245-f5d3cf589256", true); // Baarbee Cutscene
        Instance.SetWorldState("5ce3d8ff-05df-415e-8780-f85c12aad031", true); // Terry and Terri Cutscene
        Instance.SetWorldState("143e2057-16da-4a62-9f1b-691232af8786", true); // Allows Map Access
        Instance.SetWorldState("1ea330b4-8a3a-486e-9d8e-309273ec6acd", true); // Opens Shop
        Instance.SetWorldState("f1b9ccfb-51d8-4cd0-b29b-a433b491b663", true); // Baaptiste Defeated
        Instance.SetWorldState("10a5e75b-49be-4f5d-b028-496df96df79a", true); // Oblivia Dialogue (Black Ho
        Instance.SetWorldState("4d59705f-b9dc-49c4-be51-f4d6734450c7", true); // Gauntlet Unlock
        Instance.SetWorldState("f84886d8-d6e2-49ce-bf4f-b627156ddb1a", true); // Gauntlet Unlock Cutscene
        Instance.SetWorldState("e226a1eb-c8ff-481b-b65a-ddf3a1b0c07c", true); // Virgil Interruption in 1-3
    }
}