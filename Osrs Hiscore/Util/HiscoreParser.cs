using System;
using System.Net;
using System.Threading.Tasks;

namespace Osrs_Hiscore
{
    public static class HiscoreParser
    {
        private static TaskCompletionSource<string[]> LookupTask { get; set; }

        public static async Task<string[]> Parse(string username)
        {
            var client = new WebClient();
            LookupTask = new TaskCompletionSource<string[]>();
            client.DownloadStringAsync(
                new Uri(
                    $"https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player={username}"
                )
            );
            client.DownloadStringCompleted += (_, __) => LookupTask?.SetResult(__.Result.Split(","));
            return await LookupTask.Task;
        }
    }
}