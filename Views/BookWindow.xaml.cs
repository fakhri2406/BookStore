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
                ContinuationOf = book.ContinuationOf
            };
            this.DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
