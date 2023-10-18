using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Book;
using BookStoreProjectInfrastructure.Dtos.Store;
using Mapster;

namespace BookStoreProjectAPI.SeviceInterfaces
{
    public interface IBookStoreDataService
    {
        public  Task<BookStoreDto> GetBookStoreAsync(int id);

        public  Task<int> CreateBookStoreAsync(CreateBookStoreDto createRequest);

        public  Task<int> UpdateBookStoreAsync(UpdateBookStoreDto updateRequest);

        public  Task<bool> DeleteBookStoreAsync(int id);
    }
}
