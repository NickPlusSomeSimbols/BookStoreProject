namespace BookStoreProjectInfrastructure.Dtos.Storage
{
    public record AddBookToStorageDto
    {
        public int BookId { get; set; }
        public int BookStoreId { get; set; }
        public int Amount { get; set; }
    }
}
