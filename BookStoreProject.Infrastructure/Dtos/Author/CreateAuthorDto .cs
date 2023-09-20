

namespace BookStoreProjectInfrastructure.Dtos.Author
{
    public record CreateAuthorDto
    {
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
