
using BubsyArchipelagoMod.Data;

namespace BubsyArchipelagoMod.Server;

public static class LocationSender
{
    private static Dictionary<int, bool> m_AllCheckedLocations = new Dictionary<int, bool>();

    private static List<int> m_RecentlyCheckedLocations = new List<int>();

    public static void SendAllCheckedLocations()
    {
        // TODO
    }

    public static void SendLocation(string locationID)
    {
        m_RecentlyCheckedLocations.Add(CollectableID.GetLocationID(locationID));
        // TODO
    }

    public static int[] GetCheckedLocations()
    {
        return m_AllCheckedLocations.Keys.ToArray();
    }
}