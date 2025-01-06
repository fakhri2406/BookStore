using FinalADO.Models;
using System.Windows;

namespace FinalADO.Views
{
    /// <summary>
    /// Interaction logic for SetDiscountWindow.xaml
    /// </summary>
    public partial class SetDiscountWindow : Window
    {
        public decimal Discount { get; private set; }
        private readonly Book book;

        public SetDiscountWindow(Book book)
        {
            InitializeComponent();
            this.book = book;
            DiscountTextBox.Text = book.Discount.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(DiscountTextBox.Text, out decimal discount))
            {
                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show("Discount percentage must be between 0 and 100", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Discount = discount;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid discount percentage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
