using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Osrs_Hiscore.Events;
using Osrs_Hiscore.Models;
using Osrs_Hiscore.Util;

namespace Osrs_Hiscore.ViewModels
{
    public class SideBarViewModel : Screen
    {
        private LookupMode _selectedMode;
        public Array Modes { get; set; } = Enum.GetValues(typeof(LookupMode));


        public SideBarViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public LookupMode SelectedMode
        {
            get => _selectedMode;
            set
            {
                _selectedMode = value;
                OnPropertyChanged();
                _eventAggregator.PublishOnUIThread(new ModeChanged {Mode = value});
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IEventAggregator _eventAggregator;

        [Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}