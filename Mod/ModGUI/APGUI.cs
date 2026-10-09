
using MelonLoader;
using BubsyArchipelagoMod.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Il2CppFabraz.SaveData;
using BubsyArchipelagoMod.Patches.Menus;
using BubsyArchipelagoMod.Instances;

namespace BubsyArchipelagoMod.ModGUI;

[RegisterTypeInIl2Cpp]
public class APGUI: MonoBehaviour
{
    //public static bool ShowGUI = true;
    public static string AddressText = "archipelago.gg:38281";
    public static string SlotText = "Bubsy";
    public static string PasswordText = "";
    public static string StateText = "Disconnected";
    public static string ErrorText = "";

    private static Rect boxRect;
    private static Rect addressRect;
    private static Rect addressTextRect;
    private static Rect slotRect;
    private static Rect slotTextRect;
    private static Rect passwordRect;
    private static Rect passwordTextRect;
    private static Rect connectButtonRect;
    private static Rect errorRect;

    private static GUIStyle TextStyle = new()
    {
        fontSize = 24,
        normal =
        {
            textColor = Color.white
        }
    };
    private static GUIStyle SuccessStyle = new()
    {
        fontSize = 24,
        normal =
        {
            textColor = Color.green
        }
    };
    private static GUIStyle FailureStyle = new()
    {
        fontSize = 24,
        normal =
        {
            textColor = Color.red
        }
    };

    private static Vector2 Offset = Vector2.zero;

    public static APGUI Instance;

    enum ApGuiMode
    {
        CONNECT_INFO = 1,
        CONNECTED = 2
    }
    private ApGuiMode currentMode = ApGuiMode.CONNECT_INFO;

    public static void Initialize(Vector2 newOffset)
    {
        if (Core.Connected)
            Core.ForceDisconnect();
        SlotText = GetRandomBubsyName();
        StartDisplay(newOffset);
        if (Instance)
            return;

        GameObject newGui = new GameObject("AP GUI");
        Instance = newGui.AddComponent<APGUI>();
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
        return BubsyNames[rand_index];
        //return "";
    }

    private static bool displayGUI = false;

    public static void StartDisplay(Vector2 screenOffset)
    {
        Offset = screenOffset;
        boxRect = new Rect(Offset.x - 250, Offset.y, 400, 400);
        
        addressRect = new Rect(Offset.x - 200, Offset.y + 80, 400, 40);
        addressTextRect = new Rect(Offset.x - 200, Offset.y + 110, 280, 25);
        
        slotRect = new Rect(Offset.x - 200, Offset.y + 160, 400, 40);
        slotTextRect = new Rect(Offset.x - 200, Offset.y + 190, 280, 25);

        passwordRect = new Rect(Offset.x - 200, Offset.y + 240, 400, 40);
        passwordTextRect = new Rect(Offset.x - 200, Offset.y + 270, 280, 25);

        connectButtonRect = new Rect(Offset.x - 200, Offset.y + 320, 280, 25);
        errorRect = new Rect(Offset.x - 200, Offset.y + 360, 400, 40);

        displayGUI = true;
    }

    public static void StopDisplay()
    {
        displayGUI = false;
    }

    void OnGUI()
    {
        if (!displayGUI)
            return;

        if (currentMode == ApGuiMode.CONNECT_INFO)
        {
            GUI.Box(boxRect, "SAMPLE TEXT");
            GUI.Label(addressRect, "Address:Port", TextStyle);
            AddressText = GUI.TextField(addressTextRect, AddressText, 25);
            GUI.Label(slotRect, "Slot", TextStyle);
            SlotText = GUI.TextField(slotTextRect, SlotText, 25);
            GUI.Label(passwordRect, "Password", TextStyle);
            PasswordText = GUI.TextField(passwordTextRect, PasswordText, 25);
            GUI.Label(errorRect, ErrorText, FailureStyle);

            if (!Core.Connected && GUI.Button(connectButtonRect, "Connect"))
            {
                string[] splitAddress = AddressText.Split(':');
                if (splitAddress.Length != 2)
                {
                    ErrorText = "Address format is invalid. Expected ( address:port )";
                    return;
                }
                if (!int.TryParse(splitAddress[1], out int port))
                {
                    ErrorText = $"{splitAddress[1]} is not a valid port";
                    return;
                }
                var error = Core.TryConnectToAP(AddressText, SlotText, PasswordText);

                if (error is not null)
                {
                    ErrorText = string.Join('\n', error);
                    return;
                }

                ErrorText = "";
                displayGUI = false;
                TitleMenuPatch.LoadAPSaveFile();
                Core.StartReceivingItems();
            }

        }

        //GUI.Label()
    }
}