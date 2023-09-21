using BookStoreProjectCore;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Book;
using Mapster;
using Microsoft.EntityFrameworkCore;
using WA.Pizza.Core.Exceptions;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookDataService
    {
        private readonly BookStoreDbContext _context;

        public BookDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<BookDto> GetBookAsync(int id)
        {
            var foundBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (foundBook == null)
                throw new ItemNotFoundException("Book was not found");

            return foundBook.Adapt<BookDto>();
        }
        public async Task<int> CreateBookAsync(CreateBookDto createRequest)
        {
            var book = createRequest.Adapt<Book>();

            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();

            return book.Id;
        }
        public async Task<int> UpdateBookAsync(UpdateBookDto updateRequest)
        {
            return await Task.FromResult(0);
        }
        public async Task<int> DeleteBookAsync(int id)
        {
            return await Task.FromResult(0);
        }
    }
}
