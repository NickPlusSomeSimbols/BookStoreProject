using System.ComponentModel.DataAnnotations;

namespace BookStoreProjectCore.Abstractions
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
