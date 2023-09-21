using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Dtos.Storage
{
    public record UpdateBookToStorageDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BookStoreId { get; set; }
        public int Amount { get; set; }
    }
}
