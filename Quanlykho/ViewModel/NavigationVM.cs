using Quanlykho.Utilities;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand ShutdownCommand { get; set; }
        public ICommand HomeCommand { get; set; }
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

        private async Task Home(object obj)
        {
            CurrentView = new HomeVM();
            await Task.Yield();
        }
        private async Task Unit(object obj)
        {
            CurrentView = new UnitVM();
            await Task.Yield();
        }

        private async Task Customer(object obj)
        {
            CurrentView = new CustomerVM();
            await Task.Yield();
        }

        private async Task InputInfoes(object obj)
        {
            CurrentView = new InputInfoesVM();
            await Task.Yield();
        }

        private async Task Objects(object obj)
        {
            CurrentView = new ObjectsVM();
            await Task.Yield();
        }

        private async Task OutputInfoes(object obj)
        {
            CurrentView = new OutputInfoesVM();
            await Task.Yield();
        }

        private async Task Outputs(object obj)
        {
            CurrentView = new OutputsVM();
            await Task.Yield();
        }

        private async Task UserRoles(object obj)
        {
            CurrentView = new UserRolesVM();
            await Task.Yield();
        }

        private async Task Users(object obj)
        {
            CurrentView = new UsersVM();
            await Task.Yield();
        }

        private async Task Suplier(object obj)
        {
            CurrentView = new SuplierVM();
            await Task.Yield();
        }
        private async Task Shutdown(object obj)
        {
            Application.Current.Shutdown();
            await Task.Yield();
        }
        public NavigationVM()
        {
            HomeCommand = new AsyncRelayCommand<HomeVM>(Home,null,null);
            UnitCommand = new AsyncRelayCommand<UnitVM>(Unit, null, null);
            SuplierCommand = new AsyncRelayCommand<SuplierVM>(Suplier, null, null);
            ShutdownCommand = new AsyncRelayCommand<object>(Shutdown, null, null);
            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}