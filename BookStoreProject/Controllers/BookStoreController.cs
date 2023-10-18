using BookStoreProjectAPI.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Store;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class BookStoreController : BaseController
    {
        private readonly IBookStoreDataService _bookStoreDataService;

        public BookStoreController(IBookStoreDataService bookStoreDataService)
        {
            _bookStoreDataService = bookStoreDataService;
        }

        [HttpGet("BookStore-Get")]
        public async Task<BookStoreDto> GetBook(int id)
        {
            return await _bookStoreDataService.GetBookStoreAsync(id);
        }
        [HttpPost("BookStorage-Create")]
        public async Task<int> CreateAuthor(CreateBookStoreDto createRequest)
        {
            return await _bookStoreDataService.CreateBookStoreAsync(createRequest);
        }
        [HttpPatch("BookStore-Update")]
        public async Task<int> UpdateAuthor(UpdateBookStoreDto updateRequest)
        {
            return await _bookStoreDataService.UpdateBookStoreAsync(updateRequest);
        }
        [HttpDelete("BookStore-Delete")]
        public async Task<bool> DeletBookStore(int id)
        {
            return await _bookStoreDataService.DeleteBookStoreAsync(id);
        }
    }
}
