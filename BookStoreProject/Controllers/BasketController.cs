using BookStoreProjectAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WA.Pizza.API.Controllers;

[AllowAnonymous]
public class BasketController : BaseController
{
    /*private readonly BasketDataService _basketDataService;

    public BasketController(BasketDataService basketDataService)
    {
        _basketDataService = basketDataService;
    }

    [HttpPost("Item-Add")]
    public Task<int> AddItem(AddBasketItemRequest updateRequest)
    {
        return _basketDataService.AddItemAsync(updateRequest);
    }
    
    [HttpPatch("Item-Update")]
    public Task<int> UpdateItem(UpdateBasketItemRequest updateRequest)
    {
        return _basketDataService.UpdateItemAsync(updateRequest);
    }

    [HttpDelete("Item-Delete")]
    public Task<bool> DeleteItem(int catalogItemId, int basketId)
    {
        return _basketDataService.DeleteItemAsync(catalogItemId, basketId);
    }
    
    [HttpDelete("ClearBasket")]
    public Task<bool> ClearBasket(int basketId)
    {
        return _basketDataService.ClearBasketAsync(basketId);;
    }*/
}