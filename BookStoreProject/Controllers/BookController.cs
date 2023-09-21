using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class BookController : BaseController
{
    private readonly BookDataService _bookDataService;

    public BookController(BookDataService bookDataService)
    {
        _bookDataService = bookDataService;
    }

    [HttpDelete("Book-Get")]
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
        //return _bookDataService.UpdateBookAsync(updateRequest);
        return Task.FromResult(0);
    }
    [HttpDelete("Book-Delete")]
    public Task<bool> DeletBook()
    {
        //return _bookDataService.DeleteBookAsync();
        return  Task.FromResult(true);
    }
}