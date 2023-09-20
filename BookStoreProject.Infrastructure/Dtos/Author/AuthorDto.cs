using BookStoreProjectCore.Abstractions;

namespace BookStoreProjectInfrastructure.Dtos.Author
{
    public record AuthorDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
