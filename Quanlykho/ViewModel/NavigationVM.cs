using Quanlykho.Entity;
using Quanlykho.Utilities;
using System.Windows.Input;

namespace Quanlykho.ViewModel
{
    public class NavigationVM : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }

        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }

        private void Unit(object obj) => CurrentView = new UnitVM();

        private void Suplier(object obj) => CurrentView = new SuplierVM();

        public NavigationVM()
        {
            UnitCommand = new RelayCommand(Unit);
            SuplierCommand = new RelayCommand(Suplier);

            // Startup Page
            CurrentView = new UnitVM();
        }
    }
}