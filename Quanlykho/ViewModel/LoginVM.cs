using Quanlykho.Utilities;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;

namespace Quanlykho.ViewModel
{
    public class LoginVM
    {
        private ICommand _showButton;

        public ICommand ShowButton
        {
            get
            {
                if (_showButton == null)
                    _showButton = new AsyncRelayCommand<object>(param => CloseApp(), null);

                return _showButton;
            }
        }
        private ICommand _loginCommand;

        public ICommand LoginComnand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new AsyncRelayCommand<object>(param => ShowMainView(), null);

                return _loginCommand;
            }
        }

        public LoginVM()
        {
        }

        private async Task CloseApp()
        {
            Application.Current.Shutdown();
            await Task.Yield();
        }
        private async Task ShowMainView()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            await Task.Yield();
        }
    }
}