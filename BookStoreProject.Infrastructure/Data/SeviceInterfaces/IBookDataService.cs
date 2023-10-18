using BookStoreProjectCore;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Book;
using Mapster;
using BookStoreProjectCore.Exceptions;

namespace BookStoreProjectInfrastructure.Data.SeviceInterfaces
{
    public interface IBookDataService
    {
        public Task<BookDto> GetBookAsync(int id);

        public Task<int> CreateBookAsync(CreateBookDto createRequest);

        public Task<int> UpdateBookAsync(UpdateBookDto updateRequest);

        public Task<bool> DeleteBookAsync(int id);
    }
}
