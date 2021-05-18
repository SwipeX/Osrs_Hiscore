using System.ComponentModel;
using Caliburn.Micro;
using Osrs_Hiscore.Events;
using Osrs_Hiscore.Models;
using Osrs_Hiscore.Util;

namespace Osrs_Hiscore.ViewModels
{
    public class ResultsViewModel : Conductor<object>, IHandle<NameChanged>, IHandle<ModeChanged>
    {
        public HiscoreAccount Account
        {
            get => _account;
            set
            {
                _account = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Account)));
                if (value == default)
                {
                    ActivateItem(NotFound);
                    return;
                }

                Results.ResultItems = ResultItemViewModel.Create(value);
                ActivateItem(Results);
            }
        }

        public string LastName { get; set; }
        public LookupMode LastMode { get; set; } = LookupMode.Normal;
        public SearchViewModel Search { get; }
        public ResultsWrapViewModel Results { get; }
        public NotFoundViewModel NotFound { get; set; }

        public ResultsViewModel(
            IEventAggregator eventAggregator,
            SearchViewModel searchViewModel,
            ResultsWrapViewModel results,
            NotFoundViewModel notFound
        )
        {
            eventAggregator.Subscribe(this);
            Results = results;
            NotFound = notFound;
            Search = searchViewModel;
        }

        public async void Handle(NameChanged changed)
        {
            Account = await HiscoreParser.For(changed.Name, LastMode);
            LastName = changed.Name;
        }

        public async void Handle(ModeChanged changed)
        {
            Account = await HiscoreParser.For(LastName, changed.Mode);
            LastMode = changed.Mode;
        }

        private HiscoreAccount _account;
    }
}