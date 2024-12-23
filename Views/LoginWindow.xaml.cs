﻿using FinalADO.ViewModels;
using FinalADO.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalADO.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            this.DataContext = viewModel;
            viewModel.LoginSuccess += OnLoginSuccess;
        }

        private void OnLoginSuccess(Models.User user)
        {
            if (user.Username == "admin")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else
            {
                UserWindow userWindow = new UserWindow(user);
                userWindow.Show();
            }
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Username = UsernameTextBox.Text;
            viewModel.Password = PasswordBox.Password;

            viewModel.Login();
        }

        private void GoToRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
