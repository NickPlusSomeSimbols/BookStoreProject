﻿using BookStoreProjectInfrastructure.Data.Services;
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