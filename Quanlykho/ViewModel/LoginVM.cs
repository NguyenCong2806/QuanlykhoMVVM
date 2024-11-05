using Quanlykho.Utilities;
using System.Threading.Tasks;
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

        public LoginVM()
        {
        }

        private async Task CloseApp()
        {
            Application.Current.Shutdown();
            await Task.Yield();
        }
    }
}