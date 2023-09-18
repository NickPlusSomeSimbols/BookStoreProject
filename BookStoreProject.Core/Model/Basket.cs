namespace BookStoreProject.Model
{
    public class Basket : BaseEntity
    {
        public string? CustomerId { get; set; }
        public ICollection<BasketItem>? Items { get; set; } = new List<BasketItem>();
    }
}
