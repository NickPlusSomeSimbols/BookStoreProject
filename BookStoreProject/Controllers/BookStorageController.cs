using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Dtos.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class BookStorageController : BaseController
    {
        private readonly BookStorageDataService _bookStorageDataService;

        public BookStorageController(BookStorageDataService bookStorageDataService)
        {
            _bookStorageDataService = bookStorageDataService;
        }

        [HttpGet("StorageBook-Get")]
        public async Task<BookStorageDto> GetBook(int id)
        {
            return await _bookStorageDataService.GetStorageAsync(id);
        }
        [HttpPost("StorageBook-Create")]
        public async Task<int> CreateAuthor(AddBookToStorageDto createRequest)
        {
            return await _bookStorageDataService.AddBookToStorageAsync(createRequest);
        }
        [HttpPatch("StorageBook-Update")]
        public async Task<int> UpdateAuthor(UpdateBookToStorageDto updateRequest)
        {
            return await _bookStorageDataService.UpdateBookToStorageAsync(updateRequest);
        }
        [HttpDelete("StoreBook-Delete")]
        public async Task<bool> DeletBookStore(int id)
        {
            return await _bookStorageDataService.DeleteBookFromStorageAsync(id);
        }
    }
}
