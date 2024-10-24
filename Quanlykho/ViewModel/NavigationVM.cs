using Quanlykho.Utilities;
using System.Threading.Tasks;
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
        public ICommand CustomerCommand { get; set; }
        public ICommand InputInfoesCommand { get; set; }
        public ICommand InputsCommand { get; set; }
        public ICommand ObjectsCommand { get; set; }
        public ICommand OutputInfoesCommand { get; set; }
        public ICommand OutputsCommand { get; set; }
        public ICommand UserRolesCommand { get; set; }
        public ICommand UsersCommand { get; set; }
        public ICommand SuplierCommand { get; set; }

        private async Task Unit(object obj)
        {
            CurrentView = new UnitVM();
            await Task.Yield();
        }

        private void Customer(object obj) => CurrentView = new CustomerVM();

        private void InputInfoes(object obj) => CurrentView = new InputInfoesVM();

        private void Objects(object obj) => CurrentView = new ObjectsVM();

        private void OutputInfoes(object obj) => CurrentView = new OutputInfoesVM();

        private void Outputs(object obj) => CurrentView = new OutputsVM();

        private void UserRoles(object obj) => CurrentView = new UserRolesVM();

        private void Users(object obj) => CurrentView = new UsersVM();

        private void Suplier(object obj) => CurrentView = new SuplierVM();

        public NavigationVM()
        {
            //UnitCommand = new RelayCommand(Unit);
            UnitCommand = new AsyncRelayCommand<UnitVM>(Unit, null, null);
            SuplierCommand = new RelayCommand(Suplier);

            // Startup Page
            CurrentView = new UnitVM();
        }
    }
}