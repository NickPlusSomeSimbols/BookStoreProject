namespace BookStoreProject.Model
{
    public class BasketItem : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Basket? Basket { get; set; }
        public CatalogItem? CatalogItem { get; set; }
        public int CatalogItemId { get; set; }
        public int BasketId { get; set; }
    }
}
