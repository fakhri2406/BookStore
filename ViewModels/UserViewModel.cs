using FinalADO.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace FinalADO.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly DataAccess.DataAccess dataAccess;
        private readonly int userId;

        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged();
            }
        }

        private Book selectedBook;
        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel(int userId)
        {
            this.userId = userId;
            dataAccess = new DataAccess.DataAccess();
            LoadBooks();
        }

        public void LoadBooks()
        {
            Books = new ObservableCollection<Book>(dataAccess.GetAllBooks());
        }

        public void PurchaseBook()
        {
            if (SelectedBook != null)
            {
                dataAccess.SellBook(SelectedBook.BookId);
                dataAccess.AddPurchase(userId, SelectedBook.BookId);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Select a book to purchase", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
