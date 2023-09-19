using BookStoreProject.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class Author : BaseEntity
    {
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
