using FinalADO.ViewModels;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly AdminViewModel viewModel;

        public AdminWindow()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();
            this.DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BookWindow bookWindow = new BookWindow();
            if (bookWindow.ShowDialog() == true)
            {
                viewModel.AddBook(bookWindow.Book);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedBook != null)
            {
                BookWindow bookWindow = new BookWindow(viewModel.SelectedBook);
                if (bookWindow.ShowDialog() == true)
                {
                    viewModel.EditBook(bookWindow.Book);
                }
            }
            else
            {
                MessageBox.Show("Select a book to edit", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedBook != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete '{viewModel.SelectedBook.Title}'?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    viewModel.DeleteBook();
                }
            }
            else
            {
                MessageBox.Show("Select a book to delete", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
