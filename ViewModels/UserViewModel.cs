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

        private ObservableCollection<Book> allBooks;

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
            var bookList = dataAccess.GetAllBooks();
            Books = new ObservableCollection<Book>(bookList);
            allBooks = new ObservableCollection<Book>(bookList);
        }

        public void PurchaseBook()
        {
            if (SelectedBook != null)
            {
                decimal finalPrice = SelectedBook.SalePrice * (1 - SelectedBook.Discount / 100);

                var result = MessageBox.Show($"Confirm purchase of '{SelectedBook.Title}' for {finalPrice:C}?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    dataAccess.SellBook(SelectedBook.BookId);
                    dataAccess.AddPurchase(userId, SelectedBook.BookId);
                    LoadBooks();
                    MessageBox.Show("Purchase successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Select a book to purchase", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void SearchBooks(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                Books = new ObservableCollection<Book>(allBooks);
                return;
            }

            var filtered = allBooks.Where(b =>
                b.Title.ToLower().Contains(query.ToLower()) ||
                b.Author.ToLower().Contains(query.ToLower()) ||
                b.Genre.ToLower().Contains(query.ToLower()) ||
                b.Publisher.ToLower().Contains(query.ToLower())
            );

            Books = new ObservableCollection<Book>(filtered);
        }

        public void ClearSearch()
        {
            Books = new ObservableCollection<Book>(allBooks);
        }
    }
}
