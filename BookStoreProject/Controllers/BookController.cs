using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Book;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class BookController : BaseController
{
    private readonly BookDataService _bookDataService;

    public BookController(BookDataService bookDataService)
    {
        _bookDataService = bookDataService;
    }

    [HttpGet("Book-Get")]
    public Task<BookDto> GetBook(int id)
    {
        return _bookDataService.GetBookAsync(id);
    }
    [HttpPost("Book-Create")]
    public Task<int> CreateBook(CreateBookDto createRequest)
    {
        return _bookDataService.CreateBookAsync(createRequest);
    }
    [HttpPatch("Book-Update")]
    public Task<int> UpdateBook(UpdateBookDto updateRequest)
    {
        return _bookDataService.UpdateBookAsync(updateRequest);
    }
    [HttpDelete("Book-Delete")]
    public Task<bool> DeletBook(int id)
    {
        return _bookDataService.DeleteBookAsync(id);
    }
}