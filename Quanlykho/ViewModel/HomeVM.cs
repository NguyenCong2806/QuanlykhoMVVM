using Quanlykho.Utilities;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quanlykho.ViewModel
{
    public class HomeVM
    {
        public HomeVM()
        {
        }

        private ICommand _showButton;

        public ICommand ShowButton
        {
            get
            {
                if (_showButton == null)
                    _showButton = new AsyncRelayCommand<object>(param => Show(), null);

                return _showButton;
            }
        }

        private async Task Show()
        {
            await Task.Yield();
        }
    }
}