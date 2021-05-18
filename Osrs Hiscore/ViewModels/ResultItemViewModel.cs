using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Osrs_Hiscore.Annotations;
using Osrs_Hiscore.Models;

namespace Osrs_Hiscore.ViewModels
{
    public class ResultItemViewModel : Screen
    {
        public RankedEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Entry)));
                ViewContext = value is SkillEntry ? "Skill" : "Activity";
            }
        }

        public string ViewContext
        {
            get => _viewContext;

            set
            {
                _viewContext = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ViewContext)));
            }
        }

        private ResultItemViewModel(RankedEntry entry) => Entry = entry;


        public static IEnumerable<ResultItemViewModel> Create(HiscoreAccount account)
        {
            return account?.RankedEntries.Select(entry => new ResultItemViewModel(entry));
        }

        private RankedEntry _entry;
        private string _viewContext;
    }
}