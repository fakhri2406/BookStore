using System.Windows;
using System.Windows.Controls;
using FinalADO.ViewModels;

namespace FinalADO.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterViewModel viewModel;

        public RegisterWindow()
        {
            InitializeComponent();
            viewModel = new RegisterViewModel();
            this.DataContext = viewModel;
            viewModel.RegistrationSuccess += OnRegistrationSuccess;
        }

        private void OnRegistrationSuccess()
        {
            MessageBox.Show("Registration successful", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Username = UsernameTextBox.Text;
            viewModel.Password = PasswordBox.Password;
            viewModel.Register();
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
