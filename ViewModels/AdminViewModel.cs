﻿using FinalADO.Models;
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

        public AdminViewModel()
        {
            dataAccess = new DataAccess.DataAccess();
            LoadBooks();
        }

        public void LoadBooks()
        {
            var bookList = dataAccess.GetAllBooks();
            Books = new ObservableCollection<Book>(bookList);
            allBooks = new ObservableCollection<Book>(bookList);
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
            dataAccess.DeleteBook(SelectedBook.BookId);
            LoadBooks();
        }

        public void SetDiscount(decimal discount)
        {
            if (SelectedBook != null)
            {
                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show("Discount percentage must be between 0 and 100", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                SelectedBook.Discount = discount;
                dataAccess.UpdateBook(SelectedBook);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Select a book to set discount", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
