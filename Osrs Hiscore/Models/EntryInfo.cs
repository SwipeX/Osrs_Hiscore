using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Osrs_Hiscore.Model
{
    public class EntryInfo
    {
        public string Name { get; set; }
        public string IconPath { get; set; }

        public EntryInfo(string name)
        {
            Name = name;
            IconPath = $"/View/Icons/{name.ToLower()}.png";
        }
    }
}