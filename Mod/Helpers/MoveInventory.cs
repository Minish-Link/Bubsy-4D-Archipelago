

namespace BubsyArchipelagoMod.Helpers

{
    public class MoveInventory
    {
        private static bool m_jumpUnlocked;
        private static bool m_doubleJumpUnlocked;
        private static bool m_tripleJumpUnlocked;
        private static bool m_hairballStateUnlocked;
        private static bool m_hairballBoostUnlocked;
        private static bool m_hairballBounceUnlocked;
        private static bool m_pounceUnlocked;
        private static bool m_wallClingUnlocked;
        private static bool m_wallClimbUnlocked;
        private static bool m_flutterStepUnlocked;
        private static bool m_glideUnlocked;
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
        public static bool HairballBounce
        {
            get => m_hairballBounceUnlocked;
            set => m_hairballBounceUnlocked = value;
        }
        public static bool Pounce
        {
            get => m_pounceUnlocked;
            set => m_pounceUnlocked = value;
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
        public static bool FlutterStep
        {
            get => m_flutterStepUnlocked;
            set => m_flutterStepUnlocked = value;
        }
        public static bool Glide
        {
            get => m_glideUnlocked;
            set => m_glideUnlocked = value;
        }
        public static bool SkidJump
        {
            get => m_skidJumpUnlocked;
            set => m_skidJumpUnlocked = value;
        }

        public static void UnlockProgressiveJump()
        {
            if (!Jump)
                Jump = true;
            else if (!DoubleJump)
                DoubleJump = true;
            else if (!TripleJump)
                TripleJump = true;
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
        public static void UnlockSkidJump()
        {
            SkidJump = true;
        }
        public static void UnlockFlutterStep()
        {
            FlutterStep = true;
        }
        public static void UnlockGlide()
        {
            Glide = true;
        }
        public static void UnlockPounce()
        {
            Pounce = true;
        }
        public static void UnlockHairball()
        {
            HairballState = true;
        }
        public static void UnlockHairballBoost()
        {
            HairballBoost = true;
        }
        public static void UnlockHairballBounce()
        {
            HairballBounce = true;
        }
        public static void UnlockProgressiveHairball()
        {
            if (!HairballState)
                HairballState = true;
            else if (!HairballBoost)
                HairballBoost = true;
            else if (!HairballBounce)
                HairballBounce = true;
            // TODO Add Hairball Bouncer, Air Slam, and Drift upgrades here
        }
        public static void UnlockWallCling()
        {
            WallCling = true;
        }
        public static void UnlockWallClimb()
        {
            WallClimb = true;
        }
        public static void UnlockProgressiveWallClimb()
        {
            if (!WallCling)
                WallCling = true;
            else if (!WallClimb)
                WallClimb = true;
        }
    }
}
