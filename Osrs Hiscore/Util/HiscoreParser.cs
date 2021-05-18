using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Osrs_Hiscore.Models;

namespace Osrs_Hiscore.Util
{
    public static class HiscoreParser
    {
        private static async Task<string[]> Parse(string username, LookupMode mode = LookupMode.Normal)
        {
            var client = new WebClient();
            var result = await client.DownloadStringTaskAsync(
                new Uri(
                    $"https://secure.runescape.com/m=hiscore_oldschool{mode.ToUriString()}/index_lite.ws?player={username}"
                )
            );
            return result?.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }

        private static async Task<IEnumerable<RankedEntry>> GetEntries(string name, LookupMode mode = LookupMode.Normal)
        {
            var rawText = await Parse(name, mode);
            return rawText.Select<string, RankedEntry>((csv, index) =>
                {
                    var split = csv.Split(',');
                    if (split.Length == 2)
                    {
                        return new ActivityEntry(
                            index,
                            rank: Convert.ToInt32(split[0]),
                            score: Convert.ToInt32(split[1])
                        );
                    }

                    return new SkillEntry(
                        index,
                        rank: Convert.ToInt32(split[0]),
                        level: Convert.ToInt32(split[1]),
                        experience: Convert.ToInt32(split[2])
                    );
                }
            );
        }

        public static async Task<HiscoreAccount> For(string name, LookupMode mode = LookupMode.Normal)
        {
            try
            {
                var entries = await GetEntries(name, mode);
                return new HiscoreAccount(name, entries);
            }
            //General catch-all, most likely did not exist
            catch (Exception)
            {
                return default;
            }
        }
    }
}