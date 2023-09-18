namespace BookStoreProject.Model
{
    public class Order : BaseEntity
    {
        public string? CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderItem>? Items { get; set; }
        public OrderState State { get; set; }
    }
}
