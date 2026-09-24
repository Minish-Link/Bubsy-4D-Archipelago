

namespace BubsyArchipelagoMod.Helpers
{
    public class ObjectInventory
    {
        private static bool m_ampelmannUnlocked = true;
        private static bool m_pipeEntryUnlocked = true;
        private static bool m_pipeCannonsUnlocked = true;
        private static bool m_pinheadsUnlocked = true;
        private static bool m_springsUnlocked = true;
        private static bool m_fansUnlocked = true;
        private static bool m_catToysUnlocked = true;
        private static bool m_tapeMeasuresUnlocked = true;
        private static bool m_conveyorsUnlocked = true;
        private static bool m_lowGravZonesUnlocked = true;
        private static bool m_highGravZonesUnlocked = false;

        public static bool Ampelmann
        {
            get => m_ampelmannUnlocked;
            set => m_ampelmannUnlocked = value;
        }
        public static bool PipeEntry
        {
            get => m_pipeEntryUnlocked;
            set => m_pipeEntryUnlocked = value;
        }
        public static bool PipeCannons
        {
            get => m_pipeCannonsUnlocked;
            set => m_pipeCannonsUnlocked = value;
        }
        public static bool Pinheads
        {
            get => m_pinheadsUnlocked;
            set => m_pinheadsUnlocked = value;
        }
        public static bool Springs
        {
            get => m_springsUnlocked;
            set => m_springsUnlocked = value;
        }
        public static bool Fans
        {
            get => m_fansUnlocked;
            set => m_fansUnlocked = value;
        }
        public static bool CatToys
        {
            get => m_catToysUnlocked;
            set => m_catToysUnlocked = value;
        }
        public static bool TapeMeasures
        {
            get => m_tapeMeasuresUnlocked;
            set => m_tapeMeasuresUnlocked = value;
        }
        public static bool Conveyors
        {
            get => m_conveyorsUnlocked;
            set => m_conveyorsUnlocked = value;
        }
        public static bool LowGravityZones
        {
            get => m_lowGravZonesUnlocked;
            set => m_lowGravZonesUnlocked = value;
        }
        public static bool HighGravityZones
        {
            get => m_highGravZonesUnlocked;
            set => m_highGravZonesUnlocked = value;
        }
    }
}
