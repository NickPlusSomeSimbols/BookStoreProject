using BookStoreProjectCore.Abstractions;
using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Dtos.Basket
{
    public record UpdateBasketItemDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}
