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
        public Task<BookStorageDto> GetBook(int id)
        {
            return _bookStorageDataService.GetStorageAsync(id);
        }
        [HttpPost("StorageBook-Create")]
        public Task<int> CreateAuthor(AddBookToStorageDto createRequest)
        {
            return _bookStorageDataService.AddBookToStorageAsync(createRequest);
        }
        [HttpPatch("StorageBook-Update")]
        public Task<int> UpdateAuthor(UpdateBookToStorageDto updateRequest)
        {
            return _bookStorageDataService.UpdateBookToStorageAsync(updateRequest);
        }
        [HttpDelete("StoreBook-Delete")]
        public Task<bool> DeletBookStore(int id)
        {
            return _bookStorageDataService.DeleteBookFromStorageAsync(id);
        }
    }
}
