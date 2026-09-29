
using MelonLoader;
using UnityEngine;

namespace BubsyArchipelagoMod.Components;

[RegisterTypeInIl2Cpp]
public class ShopEntryData : MonoBehaviour
{
    private string m_itemName;
    private string m_playerName;
    private string m_gameName;
    private int m_locationID;

    public string ItemName { get => m_itemName; }
    public string PlayerName { get => m_playerName; }
    public string GameName { get => m_gameName; }
    public int LocationID { get => m_locationID; }

    public void InitializeData(string itemName, string playerName, string gameName, int id)
    {
        m_itemName = itemName;
        m_playerName = playerName;
        m_gameName = gameName;
        m_locationID = id;
    }

    public void PlayAppropriateVO()
    {
        if (PlayerName == Bubsy4DArchi.PlayerName)
        {
            if (ItemName == "Silver Yarnball") { }
        }
    }
}