using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                username = value; OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value; OnPropertyChanged();
            }
        }

        public event Action? LoginSuccess;

        public LoginViewModel()
        {
            dataAccess = new DataAccess.DataAccess();
        }

        public void Login()
        {
            if (dataAccess.ValidateUser(Username, Password))
            {
                LoginSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
