using BookStoreProjectCore.Abstractions;
using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Dtos.Basket
{
    public record BasketItemDto
    {
        public string Title { get; set; }
        public int BookStorageId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
    }
}
