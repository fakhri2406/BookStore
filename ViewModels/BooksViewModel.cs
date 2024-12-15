using FinalADO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalADO.ViewModels
{
    public class BooksViewModel : BaseViewModel
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

        public BooksViewModel()
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

        public void SellBook()
        {
            if (SelectedBook != null)
            {
                dataAccess.DeleteBook(SelectedBook.BookId);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Select a book to sell", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
