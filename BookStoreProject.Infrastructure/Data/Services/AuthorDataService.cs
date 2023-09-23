using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Author;
using Mapster;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class AuthorDataService
    {
        private readonly BookStoreDbContext _context;

        public AuthorDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<AuthorDto> GetAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new ItemNotFoundException();
            }

            var authorDto = author.Adapt<AuthorDto>();

            return authorDto;
        }

        public async Task<int> CreateAuthorAsync(CreateAuthorDto createRequest)
        {
            var author = createRequest.Adapt<Author>();

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return author.Id;
        }

        public async Task<int> UpdateAuthorAsync(UpdateAuthorDto updateRequest)
        {
            var author = await _context.Authors.FindAsync(updateRequest.Id);

            if (author == null)
            {
                throw new ItemNotFoundException();
            }

            author.AuthorName = updateRequest.AuthorName;
            author.BirthDate = updateRequest.BirthDate;
            author.DeathDate = updateRequest.DeathDate;

            await _context.SaveChangesAsync();

            return author.Id;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new ItemNotFoundException();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
