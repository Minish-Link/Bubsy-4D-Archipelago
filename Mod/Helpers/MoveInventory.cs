

namespace BubsyArchipelagoMod.Helpers

{
    public class MoveInventory
    {
        private static bool m_jumpUnlocked;
        private static bool m_hairballStateUnlocked;
        private static bool m_hairballBounceUnlocked;
        private static bool m_tripleJumpUnlocked;
        private static bool m_pounceUnlocked;
        private static bool m_wallClingUnlocked;
        private static bool m_flutterStepUnlocked;
        private static bool m_glideUnlocked;
        private static bool m_hairballBoostUnlocked;

        public static bool Jump
        {
            get => m_jumpUnlocked;
            set => m_jumpUnlocked = value;
        }
        public static bool HairballState
        {
            get => m_hairballStateUnlocked;
            set => m_hairballStateUnlocked = value;
        }
        public static bool HairballBounce
        {
            get => m_hairballBounceUnlocked;
            set => m_hairballBounceUnlocked = value;
        }
        public static bool TripleJump
        {
            get => m_tripleJumpUnlocked;
            set => m_tripleJumpUnlocked = value;
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
        public static bool HairballBoost
        {
            get => m_hairballBoostUnlocked;
            set => m_hairballBoostUnlocked = value;
        }
    }
}
