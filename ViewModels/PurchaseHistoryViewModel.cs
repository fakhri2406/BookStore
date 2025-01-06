using FinalADO.Models;
using System.Collections.ObjectModel;

namespace FinalADO.ViewModels
{
    public class PurchaseHistoryViewModel : BaseViewModel
    {
        private readonly DataAccess.DataAccess dataAccess;
        private readonly int userId;

        private ObservableCollection<Purchase> purchases;
        public ObservableCollection<Purchase> Purchases
        {
            get => purchases;
            set
            {
                purchases = value;
                OnPropertyChanged();
            }
        }

        public PurchaseHistoryViewModel(int userId)
        {
            this.userId = userId;
            dataAccess = new DataAccess.DataAccess();
            LoadPurchases();
        }

        public void LoadPurchases()
        {
            Purchases = new ObservableCollection<Purchase>(dataAccess.GetPurchasesByUser(userId));
        }
    }
}
