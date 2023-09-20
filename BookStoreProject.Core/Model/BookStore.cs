using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class BookStore : BaseEntity
    {
        public string StoreName { get; set; }
        public BookSoldReport BookSoldReport { get; set; }
        public int BookSoldReportId { get; set; }
        public BookStorage BookStorage { get; set; }
        public int StorageId { get; set; }
    }
}
