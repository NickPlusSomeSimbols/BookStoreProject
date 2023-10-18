using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Storage;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProjectInfrastructure.Data.SeviceInterfaces
{
    public interface IBookStorageDataService
    {
        public Task<BookStorageDto> GetStorageAsync(int StorageId);

        public Task<int> AddBookToStorageAsync(AddBookToStorageDto createRequest);

        public Task<int> UpdateBookToStorageAsync(UpdateBookToStorageDto updateRequest);

        public Task<bool> DeleteBookFromStorageAsync(int id);
    }
}
