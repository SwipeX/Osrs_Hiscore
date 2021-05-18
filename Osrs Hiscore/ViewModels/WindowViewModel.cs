using System.Windows.Input;
using Caliburn.Micro;

namespace Osrs_Hiscore.ViewModels
{
    public class WindowViewModel : Conductor<object>
    {
        public WindowViewModel(SideBarViewModel sideBar, ResultsViewModel results)
        {
            SideBar = sideBar;
            Results = results;
        }

        public SideBarViewModel SideBar { get; set; }
        public ResultsViewModel Results { get; set; }
    }
}