using Osrs_Hiscore.Model;

namespace Osrs_Hiscore.Util
{
    public static class EntryInfoFactory
    {
        public static EntryInfo For(int index) => _infos[index];

        private static EntryInfo[] _infos = new[]
        {
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
            new EntryInfo {Name = "Overall"},
        };
    }
}