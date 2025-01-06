using FinalADO.Models;
using FinalADO.ViewModels;
using System.Windows;

namespace FinalADO.Views
{
    /// <summary>
    /// Interaction logic for PurchaseHistoryWindow.xaml
    /// </summary>
    public partial class PurchaseHistoryWindow : Window
    {
        private readonly PurchaseHistoryViewModel viewModel;
        private readonly User currentUser;

        public PurchaseHistoryWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            viewModel = new PurchaseHistoryViewModel(user.UserId);
            this.DataContext = viewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
