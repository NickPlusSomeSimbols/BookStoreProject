using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class BasketItem : BaseEntity
    {
        public string Title { get; set; }
        public BookStorage BookStorage { get; set; }
        public int BookStorageId { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
