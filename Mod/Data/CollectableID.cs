

using MelonLoader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BubsyArchipelagoMod.Data;

public static class CollectableID
{
    public static int GetLocationID(string key)
    {
        if (!gameIDtoLocID.ContainsKey(key))
        {
            MelonLogger.Msg(ConsoleColor.Yellow, $"No Location ID found for Collectable with ID of {key}");
            return 0;
        }
        return gameIDtoLocID[key];
    }

    private static Dictionary<string, int> gameIDtoLocID = new()
    {

    };

    private static string collectableJsonPath = "Mods/collectable_locations.json";

    public static bool InitializeLocationIDs()
    {
        if (!File.Exists(collectableJsonPath))
        {
            
            MelonLogger.Msg(ConsoleColor.Red, $"Can not load location IDs, {collectableJsonPath} not found.");
            return false;
        }
        
        JObject data = JObject.Parse(File.ReadAllText(collectableJsonPath));
        
        foreach(var key in data.OfType<JProperty>())
        {
            gameIDtoLocID[key.Name] = ((int)data.SelectToken(key.Name).SelectToken("id"));
        }

        MelonLogger.Msg(ConsoleColor.Green, $"Location ID Table initialized with {gameIDtoLocID.Count} entries.");
        return true;
    }
}