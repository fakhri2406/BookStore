﻿using FinalADO.Models;
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
