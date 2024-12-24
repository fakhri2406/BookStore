using FinalADO.DataAccess;
using FinalADO.Models;
using System;

namespace FinalADO.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private readonly DataAccess.DataAccess dataAccess;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public event Action<User>? LoginSuccess;

        public LoginViewModel()
        {
            dataAccess = new DataAccess.DataAccess();
        }

        public void Login()
        {
            User? user = dataAccess.ValidateUser(Username, Password);
            if (user != null)
            {
                LoginSuccess?.Invoke(user);
            }
            else
            {
                System.Windows.MessageBox.Show("Incorrect username or password", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
