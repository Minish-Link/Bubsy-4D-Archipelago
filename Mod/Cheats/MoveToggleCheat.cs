using BubsyArchipelagoMod.Helpers;
using MelonLoader;
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
            MelonLogger.Msg("Removing all Jump Items");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (MoveInventory.Jump && MoveInventory.DoubleJump && MoveInventory.TripleJump)
            {
                MoveInventory.Jump = false;
                MoveInventory.DoubleJump = false;
                MoveInventory.TripleJump = false;
                MelonLogger.Msg("Removing all Jump Items");
            }
            else
            {
                MoveInventory.UnlockProgressiveJump();
                MelonLogger.Msg("Unlocking Progressive Jump");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MelonLogger.Msg("Toggling Jump1");
            MoveInventory.Jump = !MoveInventory.Jump;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MelonLogger.Msg("Toggling Jump2");
            MoveInventory.DoubleJump = !MoveInventory.DoubleJump;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MelonLogger.Msg("Toggling Jump3");
            MoveInventory.TripleJump = !MoveInventory.TripleJump;
        }
    }
    
    private static void TogglePounce()
    {
        MelonLogger.Msg("Toggling Pounce");
        MoveInventory.Pounce = !MoveInventory.Pounce;
    }

    private static void ToggleGlide()
    {
        MelonLogger.Msg("Toggling Glide");
        MoveInventory.Glide = !MoveInventory.Glide;
    }

    private static void ToggleFlutter()
    {
        MelonLogger.Msg("Toggling Flutterstep");
        MoveInventory.FlutterStep = !MoveInventory.FlutterStep;
    }

    private static void ToggleHairball()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            MelonLogger.Msg("Removing all Hairball Items");
            MoveInventory.HairballState = false;
            MoveInventory.HairballBoost = false;
            MoveInventory.HairballBounce = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (MoveInventory.HairballState && MoveInventory.HairballBoost && MoveInventory.HairballBounce)
            {
                MelonLogger.Msg("Removing all Hairball Items");
                MoveInventory.HairballState = false;
                MoveInventory.HairballBoost = false;
                MoveInventory.HairballBounce = false;
            }
            else
            {
                MelonLogger.Msg("Unlocking Progressive Hairball");
                MoveInventory.UnlockProgressiveHairball();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MelonLogger.Msg("Toggling Hairball State");
            MoveInventory.HairballState = !MoveInventory.HairballState;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MelonLogger.Msg("Toggling Hairball Boost");
            MoveInventory.HairballBoost = !MoveInventory.HairballBoost;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MelonLogger.Msg("Toggling Hairball Bouncer");
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
            MelonLogger.Msg("Removing all Wall Climb Items");
            MoveInventory.LedgeClimb = false;
            MoveInventory.WallCling = false;
            MoveInventory.WallClimb = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (MoveInventory.LedgeClimb && MoveInventory.WallCling && MoveInventory.WallClimb)
            {
                MelonLogger.Msg("Removing all Wall Climb Items");
                MoveInventory.LedgeClimb = false;
                MoveInventory.WallCling = false;
                MoveInventory.WallClimb = false;
            }
            else
            {
                MelonLogger.Msg("Unlocking Progressive Wall Climb");
                MoveInventory.UnlockProgressiveWallClimb();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MelonLogger.Msg("Toggling Ledge Climb");
            MoveInventory.LedgeClimb = !MoveInventory.LedgeClimb;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MelonLogger.Msg("Toggling Wall Cling");
            MoveInventory.WallCling = !MoveInventory.WallCling;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MelonLogger.Msg("Toggling Wall Climb");
            MoveInventory.WallClimb = !MoveInventory.WallClimb;
        }
    }

    private static void ToggleSkid()
    {
        MelonLogger.Msg("Toggling Skid");
        MoveInventory.SkidJump = !MoveInventory.SkidJump;
    }

    private static void UnlockEverything()
    {
        MoveInventory.Jump = true;
        MoveInventory.DoubleJump = true;
        MoveInventory.TripleJump = true;
        MoveInventory.SkidJump = true;
        MoveInventory.Pounce = true;
        MoveInventory.PounceAttack = true;
        MoveInventory.PounceLandingLeap = true;
        MoveInventory.FlutterStep = true;
        MoveInventory.Glide = true;
        MoveInventory.HairballState = true;
        MoveInventory.HairballBoost = true;
        MoveInventory.HairballBrake = true;
        MoveInventory.HairballBounce = true;
        MoveInventory.LedgeClimb = true;
        MoveInventory.WallCling = true;
        MoveInventory.WallClimb = true;
    }
}
