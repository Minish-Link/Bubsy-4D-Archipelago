
using Archipelago.MultiClient.Net.Models;
using MelonLoader;
using UnityEngine;

namespace BubsyArchipelagoMod.Components;

[RegisterTypeInIl2Cpp]
public class ShopEntryData : MonoBehaviour
{
    private string m_itemName;
    private string m_playerName;
    private string m_gameName;
    private long m_locationID;

    public string ItemName { get => m_itemName; }
    public string PlayerName { get => m_playerName; }
    public string GameName { get => m_gameName; }
    public long LocationID { get => m_locationID; }

    public void InitializeData(string itemName, string playerName, string gameName, long id)
    {
        m_itemName = itemName;
        m_playerName = playerName;
        m_gameName = gameName;
        m_locationID = id;
    }

    //public void InitializeData(ScoutedItemInfo scoutedItem)
    //{
    //    m_itemName = scoutedItem.ItemDisplayName;
    //    m_playerName = scoutedItem.Player.Name;
    //    m_gameName = scoutedItem.ItemGame;
    //    m_locationID = scoutedItem.LocationId;
    //}

    public void PlayAppropriateVO()
    {
        if (PlayerName == Core.PlayerName)
        {
            if (ItemName == "Silver Yarnball") { }
        }
    }
}