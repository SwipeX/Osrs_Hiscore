using System;
using System.Collections.Generic;

namespace Osrs_Hiscore.Model
{
    public class HiscoreAccount
    {
        public string Name { get; set; }
        public DateTime Requested { get; set; }
        public IList<RankedEntry> RankedEntries { get; set; } = new List<RankedEntry>();
    }
}