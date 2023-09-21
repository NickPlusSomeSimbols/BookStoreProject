using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Store;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class BookStoreController : BaseController
    {
        private readonly BookStoreDataService _bookStoreDataService;

        public BookStoreController(BookStoreDataService bookStoreDataService)
        {
            _bookStoreDataService = bookStoreDataService;
        }

        [HttpGet("BookStore-Get")]
        public Task<BookStoreDto> GetBook(int id)
        {
            return _bookStoreDataService.GetBookStoreAsync(id);
        }
        [HttpPost("BookStorage-Create")]
        public Task<int> CreateAuthor(CreateBookStoreDto createRequest)
        {
            return _bookStoreDataService.CreateBookStoreAsync(createRequest);
        }
        [HttpPatch("BookStore-Update")]
        public Task<int> UpdateAuthor(UpdateBookStoreDto updateRequest)
        {
            return _bookStoreDataService.UpdateBookStoreAsync(updateRequest);
        }
        [HttpDelete("BookStore-Delete")]
        public Task<bool> DeletBookStore(int id)
        {
            return _bookStoreDataService.DeleteBookStoreAsync(id);
        }
    }
}
