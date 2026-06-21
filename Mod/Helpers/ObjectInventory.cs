

namespace BubsyArchipelagoMod.Helpers
{
    public class ObjectInventory
    {
        private static bool m_ampelmannUnlocked;
        private static bool m_pipeEntryUnlocked;
        private static bool m_pipeCannonsUnlocked;
        private static bool m_pinheadsUnlocked;
        private static bool m_springsUnlocked;
        private static bool m_fansUnlocked;
        private static bool m_catToysUnlocked;
        private static bool m_tapeMeasuresUnlocked;
        private static bool m_conveyorsUnlocked;

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
    }
}
