using Osrs_Hiscore.Models;

namespace Osrs_Hiscore.Util
{
    public static class EntryInfoProvider
    {
        public static EntryInfo For(int index) => _infos[index];

        private static EntryInfo[] _infos =
        {
            new EntryInfo("Overall"),
            new EntryInfo("Attack"),
            new EntryInfo("Defence"),
            new EntryInfo("Strength"),
            new EntryInfo("Hitpoints"),
            new EntryInfo("Ranged"),
            new EntryInfo("Prayer"),
            new EntryInfo("Magic"),
            new EntryInfo("Cooking"),
            new EntryInfo("Woodcutting"),
            new EntryInfo("Fletching"),
            new EntryInfo("Fishing"),
            new EntryInfo("Firemaking"),
            new EntryInfo("Crafting"),
            new EntryInfo("Smithing"),
            new EntryInfo("Mining"),
            new EntryInfo("Herblore"),
            new EntryInfo("Agility"),
            new EntryInfo("Thieving"),
            new EntryInfo("Slayer"),
            new EntryInfo("Farming"),
            new EntryInfo("Runecraft"),
            new EntryInfo("Hunter"),
            new EntryInfo("Construction")
        };
    }
}