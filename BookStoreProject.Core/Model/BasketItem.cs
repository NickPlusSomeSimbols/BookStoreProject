using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class BasketItem : BaseEntity
    {
        public BookStorage BookStorage { get; set; }
        public int BookStorageId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
    }
}
