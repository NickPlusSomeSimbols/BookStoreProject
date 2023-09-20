using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class BookController : BaseController
{
    private readonly BookDataService _bookDataService;

    public BookController(BookDataService basketDataService)
    {
        _bookDataService = basketDataService;
    }

    [HttpPost("Item-Add")]
    public Task<int> AddItem(CreateBookDto createRequest)
    {
        return System.Threading.Tasks.Task.FromResult(0); 
    }
}