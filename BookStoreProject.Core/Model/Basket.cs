using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class Basket : BaseEntity
    {
        public string? CustomerId { get; set; }
        public ICollection<BasketItem>? Books { get; set; } = new List<BasketItem>();
    }
}
