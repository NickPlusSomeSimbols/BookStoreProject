using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class BookStorage : BaseEntity
    {
        public BookStore BookStore { get; set; }
        public int BookStoreId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
    }
}
