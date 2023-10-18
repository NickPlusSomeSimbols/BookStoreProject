using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

public class AuthorController : BaseController
{
    private readonly IAuthorDataService _authorDataService;

    public AuthorController(IAuthorDataService authorDataService)
    {
        _authorDataService = authorDataService;
    }
    [Authorize]
    [HttpGet("Author-Get-Auth")]
    public async Task<AuthorDto> GetBookAuth(int id)
    {
        return await _authorDataService.GetAuthorAsync(id);
    }
    [HttpGet("Author-Get")]
    public async Task<AuthorDto> GetBook(int id)
    {
        return await _authorDataService.GetAuthorAsync(id);
    }
    [HttpPost("Author-Create")]
    public async Task<int> CreateAuthor(CreateAuthorDto createRequest)
    {
        return await _authorDataService.CreateAuthorAsync(createRequest);
    }
    [HttpPatch("Author-Update")]
    public async Task<int> UpdateAuthor(UpdateAuthorDto updateRequest)
    {
        return await _authorDataService.UpdateAuthorAsync(updateRequest);
    }
    [HttpDelete("Author-Delete")]
    public async Task<bool> DeletAuthor(int id)
    {
        return await _authorDataService.DeleteAuthorAsync(id);
    }
}