using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Author;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class BookStoreController : BaseController
    {
        private readonly BookStoreDateService _bookStoreDataService;

        /*public BookStoreController(BookStoreDateService bookStoreDataService)
        {
            _bookStoreDataService = bookStoreDataService;
        }

        [HttpGet("Author-Get")]
        public Task<AuthorDto> GetBook(int id)
        {
            return _bookStoreDataService.GetBookStoreAsync(id);
        }
        [HttpPost("Author-Create")]
        public Task<int> CreateAuthor(CreateAuthorDto createRequest)
        {
            return _bookStoreDataService.CreateBookStoreAsync(createRequest);
        }
        [HttpPatch("Author-Update")]
        public Task<int> UpdateAuthor(UpdateAuthorDto updateRequest)
        {
            return _bookStoreDataService.UpdateBookStoreAsync(updateRequest);
        }
        [HttpDelete("Author-Delete")]
        public Task<bool> DeletAuthor(int id)
        {
            return _bookStoreDataService.DeleteBookStoreAsync(id);
        }*/
    }
}
