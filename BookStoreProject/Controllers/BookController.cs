using BookStoreProjectAPI.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Book;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class BookController : BaseController
{
    private readonly IBookDataService _bookDataService;

    public BookController(IBookDataService bookDataService)
    {
        _bookDataService = bookDataService;
    }

    [HttpGet("Book-Get")]
    public async Task<BookDto> GetBook(int id)
    {
        return await _bookDataService.GetBookAsync(id);
    }
    [HttpPost("Book-Create")]
    public async Task<int> CreateBook(CreateBookDto createRequest)
    {
        return await _bookDataService.CreateBookAsync(createRequest);
    }
    [HttpPatch("Book-Update")]
    public async Task<int> UpdateBook(UpdateBookDto updateRequest)
    {
        return await _bookDataService.UpdateBookAsync(updateRequest);
    }
    [HttpDelete("Book-Delete")]
    public async Task<bool> DeletBook(int id)
    {
        return await _bookDataService.DeleteBookAsync(id);
    }
}