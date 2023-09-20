using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Dtos.Book
{
    public record BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Price { get; set; }
    }
}
