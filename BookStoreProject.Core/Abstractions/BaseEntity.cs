using System.ComponentModel.DataAnnotations;

namespace BookStoreProject.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
