using FinalADO.ViewModels;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BooksViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = DataContext as BooksViewModel;
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
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                viewModel.DeleteBook();
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedBook != null)
            {
                viewModel.SellBook();
            }
            else
            {
                MessageBox.Show("Select a book to sell", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void WriteOffButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                viewModel.WriteOffBook();
            }
        }
    }
}
