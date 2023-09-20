using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectInfrastructure.Dtos.Author
{
    public record UpdateAuthorDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
