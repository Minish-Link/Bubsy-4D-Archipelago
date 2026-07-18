


namespace BubsyArchipelagoMod.Server;

public static class LocationSender
{
    private static Dictionary<string, bool> m_AllCheckedLocations;

    public static void SendAllCheckedLocations()
    {
        // TODO
    }

    public static void SendLocation(string locationID)
    {
        m_AllCheckedLocations[locationID] = true;
        // TODO
    }

    public static string[] GetCheckedLocations()
    {
        return m_AllCheckedLocations.Keys.ToArray();
    }
}