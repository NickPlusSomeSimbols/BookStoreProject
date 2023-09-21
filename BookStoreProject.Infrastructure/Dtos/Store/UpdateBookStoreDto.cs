using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Dtos.Store
{
    public record UpdateBookStoreDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
    }
}
