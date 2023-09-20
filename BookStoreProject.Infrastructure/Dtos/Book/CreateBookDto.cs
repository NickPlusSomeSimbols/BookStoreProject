namespace BookStoreProjectInfrastructure.Dtos.Book
{
    public record CreateBookDto
    {
        public string Title { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Price { get; set; }
    }
}
