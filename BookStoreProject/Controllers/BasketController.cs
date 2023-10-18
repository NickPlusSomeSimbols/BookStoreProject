using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Basket;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class BasketController : BaseController
{
    private readonly IBasketDataService _basketDataService;

    public BasketController(IBasketDataService basketDataService)
    {
        _basketDataService = basketDataService;
    }
    
    [HttpGet("Item-Get")]
    public async Task<BasketItemDto> GetItem(int id)
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