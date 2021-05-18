using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace Osrs_Hiscore.Models
{
    public class HiscoreAccount : INotifyPropertyChanged
    {
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public DateTime Requested { get; set; }
        public IObservableCollection<RankedEntry> RankedEntries { get; set; }

        public HiscoreAccount(string name, IEnumerable<RankedEntry> rankedEntries)
        {
            Name = name;
            Requested = DateTime.Now;
            RankedEntries = new BindableCollection<RankedEntry>(rankedEntries);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
    }
}