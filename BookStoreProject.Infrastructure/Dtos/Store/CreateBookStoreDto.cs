namespace BookStoreProjectInfrastructure.Dtos.Store
{
    public record CreateBookStoreDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
    }
}
