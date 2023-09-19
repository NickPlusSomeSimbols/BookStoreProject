using BookStoreProject.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class BookSoldReport : BaseEntity
    {
        public BookStore BookStore { get; set; }
        public int StoreID { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<Book>? SoldBooks { get; set; }
        public int Income { get; set; }
    }
}
