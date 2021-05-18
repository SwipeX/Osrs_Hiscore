using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Osrs_Hiscore.Models
{
    public class EntryInfo : INotifyPropertyChanged
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

        public string IconPath
        {
            get => _iconPath;
            set
            {
                _iconPath = value;
                OnPropertyChanged();
            }
        }

        public EntryInfo(string name)
        {
            Name = char.ToUpper(name[0]) + name[1..];
            IconPath = $"/Views/Icons/{name.ToLower()}.png";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _iconPath;
        private string _name;
    }
}