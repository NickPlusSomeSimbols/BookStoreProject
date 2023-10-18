using BookStoreProjectInfrastructure.Dtos.Basket;

namespace BookStoreProjectAPI.ServiceInterfaces
{
    public interface IBasketDataService
    {

        public Task BindBuyerToBasket(string userId, int basketToBindId);
        public Task<BasketItemDto> GetItemAsync(int ItemId);
        public Task<int> AddItemAsync(AddBasketItemDto createRequest);

        public Task<int> UpdateItemAsync(UpdateBasketItemDto updateRequest);

        public Task<bool> DeleteBasketItemAsync(int basketItemId);
    }
}
