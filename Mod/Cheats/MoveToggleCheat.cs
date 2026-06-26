using BubsyArchipelagoMod.Helpers;
using UnityEngine;

namespace BubsyArchipelagoMod.Cheats;


public static class MoveToggleCheat
{
    public static bool Initialized { get; private set; }
    private static KeyCode k_toggleJump;
    private static KeyCode k_togglePounce;
    private static KeyCode k_toggleGlide;
    private static KeyCode k_toggleFlutter;
    private static KeyCode k_toggleHairball;
    private static KeyCode k_toggleWallCling;
    private static KeyCode k_toggleSkid;
    private static KeyCode k_unlockEverything;


    public static void Initialize()
    {
        if (Initialized)
            return;

        k_toggleJump = KeyCode.Keypad1;
        k_togglePounce = KeyCode.Keypad2;
        k_toggleGlide = KeyCode.Keypad3;
        k_toggleFlutter = KeyCode.Keypad4;
        k_toggleHairball = KeyCode.Keypad5;
        k_toggleWallCling = KeyCode.Keypad6;
        k_toggleSkid = KeyCode.Keypad7;
        k_unlockEverything = KeyCode.Keypad0;

        Initialized = true;
    }

    public static void ReadCheatInputs()
    {
        if (Input.GetKey(k_toggleJump))
            ToggleJump();
        else if (Input.GetKeyDown(k_togglePounce))
            TogglePounce();
        else if (Input.GetKeyDown(k_toggleGlide))
            ToggleGlide();
        else if (Input.GetKeyDown(k_toggleFlutter))
            ToggleFlutter();
        else if (Input.GetKey(k_toggleHairball))
            ToggleHairball();
        else if (Input.GetKey(k_toggleWallCling))
            ToggleWallCling();
        else if (Input.GetKeyDown(k_toggleSkid))
            ToggleSkid();
        else if (Input.GetKeyDown(k_unlockEverything))
            UnlockEverything();
    }

    private static void ToggleJump()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            MoveInventory.Jump = false;
            MoveInventory.DoubleJump = false;
            MoveInventory.TripleJump = false;
            Bubsy4DArchi.LogPatchMessage("Removing all Jump Items");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (MoveInventory.Jump && MoveInventory.DoubleJump && MoveInventory.TripleJump)
            {
                MoveInventory.Jump = false;
                MoveInventory.DoubleJump = false;
                MoveInventory.TripleJump = false;
                Bubsy4DArchi.LogPatchMessage("Removing all Jump Items");
            }
            else
            {
                MoveInventory.UnlockProgressiveJump();
                Bubsy4DArchi.LogPatchMessage("Unlocking Progressive Jump");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveInventory.Jump = !MoveInventory.Jump;
            Bubsy4DArchi.LogPatchMessage("Toggling Jump1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveInventory.DoubleJump = !MoveInventory.DoubleJump;
            Bubsy4DArchi.LogPatchMessage("Toggling Jump2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveInventory.TripleJump = !MoveInventory.TripleJump;
            Bubsy4DArchi.LogPatchMessage("Toggling Jump3");
        }
    }
    
    private static void TogglePounce()
    {
        Bubsy4DArchi.LogPatchMessage("Toggling Pounce");
        MoveInventory.Pounce = !MoveInventory.Pounce;
    }

    private static void ToggleGlide()
    {
        Bubsy4DArchi.LogPatchMessage("Toggling Glide");
        MoveInventory.Glide = !MoveInventory.Glide;
    }

    private static void ToggleFlutter()
    {
        Bubsy4DArchi.LogPatchMessage("Toggling Flutterstep");
        MoveInventory.FlutterStep = !MoveInventory.FlutterStep;
    }

    private static void ToggleHairball()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Bubsy4DArchi.LogPatchMessage("Removing all Hairball Items");
            MoveInventory.HairballState = false;
            MoveInventory.HairballBoost = false;
            MoveInventory.HairballBounce = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (MoveInventory.HairballState && MoveInventory.HairballBoost && MoveInventory.HairballBounce)
            {
                Bubsy4DArchi.LogPatchMessage("Removing all Hairball Items");
                MoveInventory.HairballState = false;
                MoveInventory.HairballBoost = false;
                MoveInventory.HairballBounce = false;
            }
            else
            {
                Bubsy4DArchi.LogPatchMessage("Unlocking Progressive Hairball");
                MoveInventory.UnlockProgressiveHairball();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bubsy4DArchi.LogPatchMessage("Toggling Hairball State");
            MoveInventory.HairballState = !MoveInventory.HairballState;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bubsy4DArchi.LogPatchMessage("Toggling Hairball Boost");
            MoveInventory.HairballBoost = !MoveInventory.HairballBoost;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Bubsy4DArchi.LogPatchMessage("Toggling Hairball Bouncer");
            MoveInventory.HairballBounce = !MoveInventory.HairballBounce;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // TODO Toggle Hairball Bouncer Upgrade
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // TODO Toggle Hairball Air Slam Upgrade
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // TODO Toggle Hairball Drift Upgrade
        }
    }

    private static void ToggleWallCling()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Bubsy4DArchi.LogPatchMessage("Removing all Wall Climb Items");
            MoveInventory.WallCling = false;
            MoveInventory.WallClimb = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (MoveInventory.WallCling && MoveInventory.WallClimb)
            {
                Bubsy4DArchi.LogPatchMessage("Removing all Wall Climb Items");
                MoveInventory.WallCling = false;
                MoveInventory.WallClimb = false;
            }
            else
            {
                Bubsy4DArchi.LogPatchMessage("Unlocking Progressive Wall Climb");
                MoveInventory.UnlockProgressiveWallClimb();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bubsy4DArchi.LogPatchMessage("Toggling Wall Cling");
            MoveInventory.WallCling = !MoveInventory.WallCling;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bubsy4DArchi.LogPatchMessage("Toggling Wall Climb");
            MoveInventory.WallClimb = !MoveInventory.WallClimb;
        }
    }

    private static void ToggleSkid()
    {
        Bubsy4DArchi.LogPatchMessage("Toggling Skid");
        MoveInventory.SkidJump = !MoveInventory.SkidJump;
    }

    private static void UnlockEverything()
    {
        MoveInventory.Jump = true;
        MoveInventory.DoubleJump = true;
        MoveInventory.TripleJump = true;
        MoveInventory.Pounce = true;
        MoveInventory.FlutterStep = true;
        MoveInventory.Glide = true;
        MoveInventory.HairballState = true;
        MoveInventory.HairballBoost = true;
        MoveInventory.HairballBounce = true;
        MoveInventory.WallCling = true;
        MoveInventory.WallClimb = true;
        MoveInventory.SkidJump = true;
    }
}
