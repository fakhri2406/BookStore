using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalADO.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string BookTitle { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice => SalePrice * (1 - Discount / 100);
    }
}
