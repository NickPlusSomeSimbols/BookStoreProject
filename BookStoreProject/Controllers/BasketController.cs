using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Basket;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public static class SomeClass
{
}
public class BasketController : BaseController
{
    private readonly BasketDataService _basketDataService;

    public BasketController(BasketDataService basketDataService)
    {
        _basketDataService = basketDataService;
    }
    [HttpGet("Item-Get")]
    public async Task<BasketItemDto> AddItem(int id)
    {
        return await _basketDataService.GetItemAsync(id);
    }
    [HttpPost("Item-Add")]
    public async Task<int> AddItem(AddBasketItemDto createRequest)
    {
        return await _basketDataService.AddItemAsync(createRequest);
    }

    [HttpPatch("Item-Update")]
    public async Task<int> UpdateItem(UpdateBasketItemDto updateRequest)
    {
        return await _basketDataService.UpdateItemAsync(updateRequest);
    }

    [HttpDelete("Item-Delete")]
    public async Task<bool> DeleteItem(int id)
    {
        return await _basketDataService.DeleteBasketItemAsync(id);
    }
}