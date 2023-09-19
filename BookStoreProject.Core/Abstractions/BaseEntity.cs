using System.ComponentModel.DataAnnotations;

namespace BookStoreProject.Abstractions
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
