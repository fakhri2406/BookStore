﻿using FinalADO.Models;
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
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public Book Book { get; set; }

        public BookWindow()
        {
            InitializeComponent();
            Book = new Book();
            this.DataContext = this;
        }

        public BookWindow(Book book) : this()
        {
            Book = new Book
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Pages = book.Pages,
                Genre = book.Genre,
                PublicationYear = book.PublicationYear,
                Cost = book.Cost,
                SalePrice = book.SalePrice,
                IsContinuation = book.IsContinuation,
                ContinuationOf = book.ContinuationOf,
                Discount = book.Discount
            };
            this.DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Book.Title))
            {
                MessageBox.Show("Title is required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Book.Author) || !Book.Author.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Author name should consist of letters only", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Book.Genre) || !Book.Genre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Genre should consist of letters only", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Book.Pages <= 0)
            {
                MessageBox.Show("Page count should be greater than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Book.PublicationYear > DateTime.Now.Year)
            {
                MessageBox.Show($"Publication year should not be greater than {DateTime.Now.Year}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Book.Discount < 0 || Book.Discount > 100)
            {
                MessageBox.Show("Discount percentage must be between 0 and 100", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
