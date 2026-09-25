
using BubsyArchipelagoMod.Helpers;
using UnityEngine;

namespace BubsyArchipelagoMod.ModGUI;

public class ConnectionGUI: MonoBehaviour
{
    //public static bool ShowGUI = true;
    public static string IPText = "archipelago.gg";
    public static string PortText = "38281";
    public static string SlotText = "Bubsy";
    public static string PasswordText = "";
    public static string StateText = "Disconnected";
    public static string ErrorText = "";

    public static ConnectionGUI Instance;

    public void Initialize()
    {
        if (!Instance)
            return;

    }

    private static string[] BubsyNames = [
        "Bubsy",
        "Tubsy",
        "Flubsy",
        "Snubsy",
        "Beebzie",
        "Glubsy",
        "Schnubsy",
        "Xoobsie",
        "Tcheikovsky",
        "Trubsy",
        "Bulbschy",
        "Bucky",
        "Booby",
        "Bootsy",
        "Bunky",
        "Bumpy",
        "Buster",
        "Bitsy",
        "Baldy",
        "Baabsy"
    ];

    public static string GetRandomBubsyName()
    {
        if (BubsyNames.Length == 0)
            return "Bubsy";

        System.Random rand = new System.Random();
        int rand_index = rand.Next() % BubsyNames.Length;
        return "";
    }

    private void Awake()
    {
        SlotText = GetRandomBubsyName();

        //string[] fileText = File.ReadAllLines("ConnectionInfo.txt");
        //if (fileText.Length < 4)
        //{
        //    SlotText = GetRandomBubsyName();
        //    return;
        //}
        //IPText = fileText[0];
        //PortText = fileText[1];
        //SlotText = fileText[2];
        //PasswordText = fileText[3];
    }

    public void TryConnect()
    {

    }

}