namespace FinalADO.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public decimal Cost { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsContinuation { get; set; }
        public int? ContinuationOf { get; set; }
        public int SalesCount { get; set; }
        public decimal Discount { get; set; }
    }
}
