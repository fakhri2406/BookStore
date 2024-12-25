using FinalADO.Models;
using FinalADO.ViewModels;
using System.Windows;

namespace FinalADO.Views
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly UserViewModel viewModel;
        private readonly User currentUser;

        public UserWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            viewModel = new UserViewModel(user.UserId);
            this.DataContext = viewModel;
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PurchaseBook();
        }

        private void PurchaseHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseHistoryWindow historyWindow = new PurchaseHistoryWindow(currentUser);
            historyWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text.Trim();
            viewModel.SearchBooks(query);
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            viewModel.ClearSearch();
        }
    }
}
