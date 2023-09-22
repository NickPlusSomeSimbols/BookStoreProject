using BookStoreProjectCore.Abstractions;
using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Dtos.Basket
{
    public record AddBasketItemDto
    {
        public int BookStorageId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
    }
}
