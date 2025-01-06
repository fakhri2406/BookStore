using FinalADO.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
