

using Il2CppFabraz.SaveData;
using Il2CppFabraz.Settings;

namespace BubsyArchipelagoMod.Helpers

{
    public class MoveInventory
    {
        #region Jump Unlocks
        private static bool m_jumpUnlocked;
        private static bool m_doubleJumpUnlocked;
        private static bool m_tripleJumpUnlocked;

        private static bool m_skidJumpUnlocked;

        public static bool Jump
        {
            get => m_jumpUnlocked;
            set => m_jumpUnlocked = value;
        }
        public static bool DoubleJump
        {
            get => m_doubleJumpUnlocked;
            set => m_doubleJumpUnlocked = value;
        }
        public static bool TripleJump
        {
            get => m_tripleJumpUnlocked;
            set => m_tripleJumpUnlocked = value;
        }

        public static bool SkidJump
        {
            get => m_skidJumpUnlocked;
            set => m_skidJumpUnlocked = value;
        }

        public static void UnlockJump1()
        {
            Jump = true;
        }
        public static void UnlockJump2()
        {
            DoubleJump = true;
        }
        public static void UnlockJump3()
        {
            TripleJump = true;
        }
        public static void UnlockProgressiveJump()
        {
            if (!Jump)
                UnlockJump1();
            else if (!DoubleJump)
                UnlockJump2();
            else if (!TripleJump)
                UnlockJump3();
        }

        public static void UnlockSkidJump()
        {
            SkidJump = true;
        }

        private static void LockAllJumps()
        {
            Jump = false;
            DoubleJump = false;
            TripleJump = false;
            SkidJump = false;
        }

        #endregion

        #region Pounce Unlocks
        private static bool m_pounceUnlocked;
        private static bool m_pounceAttackUnlocked;
        private static bool m_pounceLandingLeapUnlocked;

        public static bool PounceAttack
        {
            get => m_pounceAttackUnlocked;
            set => m_pounceAttackUnlocked = value;
        }
        public static bool Pounce
        {
            get => m_pounceUnlocked;
            set => m_pounceUnlocked = value;
        }
        public static bool PounceLandingLeap
        {
            get => m_pounceLandingLeapUnlocked;
            set => m_pounceLandingLeapUnlocked = value;
        }

        public static void UnlockPounceAttack()
        {
            PounceAttack = true;
        }
        public static void UnlockPounce()
        {
            Pounce = true;
        }
        public static void UnlockPounceLandingLeap()
        {
            PounceLandingLeap = true;
        }
        public static void UnlockProgressivePounce()
        {
            if (!PounceAttack)
                UnlockPounceAttack();
            else if (!Pounce)
                UnlockPounce();
            else if (!PounceLandingLeap)
                UnlockPounceLandingLeap();
        }

        private static void LockAllPounces()
        {
            PounceAttack = false;
            Pounce = false;
            PounceLandingLeap = false;
        }

        #endregion

        #region HairballUnlocks
        private static bool m_hairballStateUnlocked;
        private static bool m_hairballBoostUnlocked;
        private static bool m_hairballBrakeUnlocked;
        private static bool m_hairballBounceUnlocked;

        public static bool HairballState
        {
            get => m_hairballStateUnlocked;
            set => m_hairballStateUnlocked = value;
        }
        public static bool HairballBoost
        {
            get => m_hairballBoostUnlocked;
            set => m_hairballBoostUnlocked = value;
        }
        public static bool HairballBrake
        {
            get => m_hairballBrakeUnlocked;
            set => m_hairballBrakeUnlocked = value;
        }
        public static bool HairballBounce
        {
            get => m_hairballBounceUnlocked;
            set => m_hairballBounceUnlocked = value;
        }

        public static void UnlockHairball()
        {
            HairballState = true;
        }
        public static void UnlockHairballBoost()
        {
            HairballBoost = true;
        }
        public static void UnlockHairballBrake()
        {
            HairballBrake = true;
        }
        public static void UnlockHairballBounce()
        {
            HairballBounce = true;
        }
        public static void UnlockProgressiveHairball()
        {
            if (!HairballState)
                UnlockHairball();
            else if (!HairballBoost)
                UnlockHairballBoost();
            else if (!HairballBrake)
                UnlockHairballBrake();
            else if (!HairballBounce)
                UnlockHairballBounce();
            else if (!VanillaShopHelper.IsUpgradeOrOutfitUnlocked("Hairball Bouncer"))
                VanillaShopHelper.TryUnlockUpgradeOrOutfit("Hairball Bouncer");
            else if (!VanillaShopHelper.IsUpgradeOrOutfitUnlocked("Hairball Air Slam"))
                VanillaShopHelper.TryUnlockUpgradeOrOutfit("Hairball Air Slam");
            else if (!VanillaShopHelper.IsUpgradeOrOutfitUnlocked("Hairball Drift"))
                VanillaShopHelper.TryUnlockUpgradeOrOutfit("Hairball Drift");
        }

        private static void LockAllHairballs()
        {
            HairballState = false;
            HairballBoost = false;
            HairballBrake = false;
            HairballBounce = false;
        }
        #endregion

        #region Wall Climb Unlocks
        private static bool m_ledgeClimbUnlocked;
        private static bool m_wallClingUnlocked;
        private static bool m_wallClimbUnlocked;
        private static bool m_wallJumpUnlocked;

        public static bool LedgeClimb
        {
            get => m_ledgeClimbUnlocked;
            set => m_ledgeClimbUnlocked = value;
        }
        public static bool WallCling
        {
            get => m_wallClingUnlocked;
            set => m_wallClingUnlocked = value;
        }
        public static bool WallClimb
        {
            get => m_wallClimbUnlocked;
            set => m_wallClimbUnlocked = value;
        }
        public static bool WallJump
        {
            get => m_wallJumpUnlocked;
            set => m_wallJumpUnlocked = value;
        }

        public static void UnlockLedgeClimb()
        {
            LedgeClimb = true;
        }
        public static void UnlockWallCling()
        {
            WallCling = true;
        }
        public static void UnlockWallClimb()
        {
            WallClimb = true;
        }
        public static void UnlockWallJump()
        {
            WallJump = true;
        }
        public static void UnlockProgressiveWallClimb()
        {
            if (!LedgeClimb)
                UnlockLedgeClimb();
            else if (!WallCling)
                UnlockWallCling();
            else if (!WallClimb)
                UnlockWallClimb();
            else if (!VanillaShopHelper.IsUpgradeOrOutfitUnlocked("Wall Claws"))
                VanillaShopHelper.TryUnlockUpgradeOrOutfit("Wall Claws");
        }

        private static void LockAllWallClimbs()
        {
            LedgeClimb = false;
            WallCling = false;
            WallClimb = false;
        }
        #endregion

        #region Miscellaneous
        private static bool m_flutterStepUnlocked;
        public static bool FlutterStep
        {
            get => m_flutterStepUnlocked;
            set => m_flutterStepUnlocked = value;
        }
        public static void UnlockFlutterStep()
        {
            FlutterStep = true;
        }

        private static bool m_glideUnlocked;
        public static bool Glide
        {
            get => m_glideUnlocked;
            set => m_glideUnlocked = value;
        }
        public static void UnlockGlide()
        {
            Glide = true;
        }

        private static bool m_cameraFreeLookUnlocked;
        private static bool m_cameraReorientUnlocked;
        public static bool CameraFreeLook
        {
            get => m_cameraFreeLookUnlocked;
            set => m_cameraFreeLookUnlocked = value;
        }
        public static bool CameraReorient
        {
            get => m_cameraReorientUnlocked;
            set => m_cameraReorientUnlocked = value;
        }

        private static bool m_tankControlsUnlocked;
        public static bool TankControls
        {
            get => m_tankControlsUnlocked;
            set => m_tankControlsUnlocked = value;
        }

        public static void UnlockTankControls()
        {
            TankControls = true;
            SaveDataManager.Instance.Settings.AdjustSetting("81b09809-6bf4-4dce-a53d-0c7348fc27c6", false, false, true);
        }

        private static void LockAllMiscellaneous()
        {
            FlutterStep = false;
            Glide = false;
            CameraFreeLook = false;
            CameraReorient = false;
            TankControls = false;
            SaveDataManager.Instance.Settings.AdjustSetting("81b09809-6bf4-4dce-a53d-0c7348fc27c6", true, false, true);
        }

        #endregion

        public static void LockAllMoveItems()
        {
            LockAllJumps();
            LockAllPounces();
            LockAllHairballs();
            LockAllWallClimbs();
            LockAllMiscellaneous();
        }
    }
}
