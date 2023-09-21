using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class BookSoldReport : BaseEntity
    {
        public BookStore BookStore { get; set; }
        public int BookStoreId { get; set; }
        public DateTime? Date { get; set; }
        public Book SoldBook { get; set; }
        public int SoldBookId { get; set; }
        public int Amount { get; set; }
        public int Income { get; set; }
    }
}
