using BookStoreProject.Abstractions;

namespace BookStoreProjectCore.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Price { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
