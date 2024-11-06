using Quanlykho.Utilities;

namespace Quanlykho.Model
{
    public class LoginModel : ViewModelBase
    {
        private bool _isCheckLogin { get; set; }
        public bool IsCheckLogin
        {
            get { return _isCheckLogin; }
            set
            {
                _isCheckLogin = value;
                OnPropertyChanged(nameof(IsCheckLogin));
            }
        }
        private string _notification { get; set; }
        public string Notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                OnPropertyChanged(nameof(Notification));
            }
        }
    }
}