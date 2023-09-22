using BookStoreProjectAPI.Controllers;
using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WA.Pizza.API.Controllers;

[AllowAnonymous]
public class BasketController : BaseController
{
    private readonly BasketDataService _basketDataService;

    public BasketController(BasketDataService basketDataService)
    {
        _basketDataService = basketDataService;
    }
    [HttpGet("Item-Get")]
    public Task<BasketItemDto> AddItem(int id)
    {
        return _basketDataService.GetItemAsync(id);
    }
    [HttpPost("Item-Add")]
    public Task<int> AddItem(AddBasketItemDto updateRequest)
    {
        return _basketDataService.AddItemAsync(updateRequest);
    }
    
    [HttpPatch("Item-Update")]
    public Task<int> UpdateItem(UpdateBasketItemDto updateRequest)
    {
        return _basketDataService.UpdateItemAsync(updateRequest);
    }

    [HttpDelete("Item-Delete")]
    public Task<bool> DeleteItem(int id)
    {
        return _basketDataService.DeleteBasketItemAsync(id);
    }
}