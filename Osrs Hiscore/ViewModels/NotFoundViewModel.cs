using System.ComponentModel;
using System.Windows.Input;
using Caliburn.Micro;
using Osrs_Hiscore.Events;
using Osrs_Hiscore.Models;

namespace Osrs_Hiscore.ViewModels
{
    public class NotFoundViewModel : Screen, IHandle<NameChanged>, IHandle<ModeChanged>
    {
        public string LastName { get; set; }
        public LookupMode LastMode { get; set; } = LookupMode.Normal;

        public NotFoundViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public void Handle(NameChanged changed)
        {
            LastName = changed.Name;
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(LastName)));
        }

        public void Handle(ModeChanged changed)
        {
            LastMode = changed.Mode;
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(LastMode)));
        }
    }
}