using Quanlykho.Model;
using Quanlykho.Utilities;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;

namespace Quanlykho.ViewModel
{
    public class LoginVM
    {
        public bool IsLogin { get; set; }=false;
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
        public ICommand LoginComnand { get; set; }
        public LoginModel LoginModel { get; set; }
        public LoginVM()
        {
            IsLogin = false;
            LoginModel = new LoginModel();
            LoginComnand = new AsyncRelayCommand<object>(param => ShowMainView(param), null);
        }

        private async Task CloseApp()
        {
            Application.Current.Shutdown();
            await Task.Yield();
        }
        private async Task ShowMainView(object obj)
        {
            var loginview = obj as Window;
            if (loginview == null) return;
            
            IsLogin = true;
            loginview.Close();

             await Task.Yield();
        }
    }
}