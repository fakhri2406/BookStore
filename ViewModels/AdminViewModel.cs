using FinalADO.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace FinalADO.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly DataAccess.DataAccess dataAccess;

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

        public AdminViewModel()
        {
            dataAccess = new DataAccess.DataAccess();
            LoadBooks();
        }

        public void LoadBooks()
        {
            Books = new ObservableCollection<Book>(dataAccess.GetAllBooks());
        }

        public void AddBook(Book book)
        {
            dataAccess.AddBook(book);
            LoadBooks();
        }

        public void EditBook(Book book)
        {
            dataAccess.UpdateBook(book);
            LoadBooks();
        }

        public void DeleteBook()
        {
            if (SelectedBook != null)
            {
                dataAccess.DeleteBook(SelectedBook.BookId);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Select a book to delete", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void WriteOffBook()
        {
            if (SelectedBook != null)
            {
                dataAccess.DeleteBook(SelectedBook.BookId);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Select a book to write off", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
