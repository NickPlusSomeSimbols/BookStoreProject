using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Author;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class AuthorController : BaseController
{
    private readonly AuthorDataService _authorDataService;

    public AuthorController(AuthorDataService authorDataService)
    {
        _authorDataService = authorDataService;
    }

    [HttpGet("Author-Get")]
    public Task<AuthorDto> GetBook(int id)
    {
        return _authorDataService.GetAuthorAsync(id);
    }
    [HttpPost("Author-Create")]
    public Task<int> CreateAuthor(CreateAuthorDto createRequest)
    {
        return _authorDataService.CreateAuthorAsync(createRequest);
    }
    [HttpPatch("Author-Update")]
    public Task<int> UpdateAuthor(UpdateAuthorDto updateRequest)
    {
        return _authorDataService.UpdateAuthorAsync(updateRequest);
    }
    [HttpDelete("Author-Delete")]
    public Task<bool> DeletAuthor(int id)
    {
        return _authorDataService.DeleteAuthorAsync(id);
    }
}