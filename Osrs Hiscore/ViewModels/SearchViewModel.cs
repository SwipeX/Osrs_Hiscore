using Caliburn.Micro;
using Osrs_Hiscore.Events;

namespace Osrs_Hiscore.ViewModels
{
    public class SearchViewModel: Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public SearchViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        //Event Action used via Caliburn
        public void TextUpdated(string text) => _eventAggregator.PublishOnUIThread(new NameChanged {Name = text});
    }
}