namespace BubsyArchipelagoMod.Server;

public struct LocationData
{
    public string PlayerName { get; private set; }
    public string ItemName { get; private set; }
    public int ItemClassification { get; private set; }
    public int LocationCode { get; private set; }


    public LocationData(string gameName, string playerName, string itemName, int itemClass, int locationCode)
    {
        PlayerName = playerName;
        ItemName = itemName;
        ItemClassification = itemClass;
        LocationCode = locationCode;
    }

    public bool IsProgression()
    {
        return (ItemClassification & 1) != 0;
    }
    public bool IsUseful()
    {
        return (ItemClassification & 2) != 0;
    }
    public bool IsTrap()
    {
        return (ItemClassification & 4) != 0;
    }

    public string GetDisplayString()
    {
        return $"{ItemName} for {PlayerName}";
    }

    public void SendLocation()
    {
        // TODO
    }
}