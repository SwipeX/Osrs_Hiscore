using System;

namespace Osrs_Hiscore.Models
{
    public enum LookupMode
    {
        Normal,
        Ironman,
        UltimateIronman,
        HardcoreIronman,
        Deadman,
        Leagues,
        Tournament
    }

    public static class LookupModeExtentions
    {
        public static string ToUriString(this LookupMode mode)
        {
            switch (mode)
            {
                case LookupMode.Normal:
                    return "";
                case LookupMode.Ironman :
                    return "_ironman";
                case LookupMode.UltimateIronman:
                    return "_ultimate";
                case LookupMode.HardcoreIronman:
                    return "_hardcore_ironman";;
                case LookupMode.Deadman:
                    return "_deadman";
                case LookupMode.Leagues:
                    return "_seasonal";
                case LookupMode.Tournament:
                    return "_tournament";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}