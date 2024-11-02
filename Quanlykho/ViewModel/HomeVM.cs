using BespokeFusion;
using Quanlykho.Utilities;
using SweetAlertSharp;
using SweetAlertSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
