using FinalADO.DataAccess;
using FinalADO.Models;
using System;
using System.Windows;

namespace FinalADO.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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

        public event Action? RegistrationSuccess;

        public RegisterViewModel()
        {
            dataAccess = new DataAccess.DataAccess();
        }

        public void Register()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter both username and password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Password.Length < 8)
            {
                MessageBox.Show("Password should be at least 8 symbols long", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var newUser = new User
                {
                    Username = Username,
                    Password = Password
                };

                dataAccess.AddUser(newUser);
                RegistrationSuccess?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
