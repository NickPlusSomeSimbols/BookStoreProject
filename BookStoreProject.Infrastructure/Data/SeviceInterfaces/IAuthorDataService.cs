using BookStoreProjectInfrastructure.Dtos.Author;

namespace BookStoreProjectAPI.SeviceInterfaces
{
    public interface IAuthorDataService
    {
        public Task<AuthorDto> GetAuthorAsync(int id);
        public Task<int> CreateAuthorAsync(CreateAuthorDto createRequest);
        public Task<int> UpdateAuthorAsync(UpdateAuthorDto updateRequest);
        public Task<bool> DeleteAuthorAsync(int id);
    }
}
