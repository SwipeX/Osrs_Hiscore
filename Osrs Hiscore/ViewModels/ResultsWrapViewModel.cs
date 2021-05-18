using System.Collections.Generic;
using System.ComponentModel;
using Caliburn.Micro;

namespace Osrs_Hiscore.ViewModels
{
    public class ResultsWrapViewModel : Screen
    {
        public IEnumerable<ResultItemViewModel> ResultItems
        {
            get => _resultItems;
            set
            {
                _resultItems = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ResultItems)));
            }
        }

        private IEnumerable<ResultItemViewModel> _resultItems;
    }
}