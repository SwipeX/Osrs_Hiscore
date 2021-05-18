using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Osrs_Hiscore.Util;

namespace Osrs_Hiscore.Models
{
    public abstract class RankedEntry : INotifyPropertyChanged
    {
        public int Rank
        {
            get => _rank;
            set
            {
                _rank = value;
                OnPropertyChanged();
            }
        }

        public EntryInfo Info
        {
            get => _info;
            set
            {
                _info = value;
                OnPropertyChanged();
            }
        }

        protected RankedEntry(int index, int rank)
        {
            Rank = rank;
            try
            {
                Info = new EntryInfo(RankedEntryNames.All[index]);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _rank;
        private EntryInfo _info;
    }
}