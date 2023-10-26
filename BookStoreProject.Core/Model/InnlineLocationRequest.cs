using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectCore.Model
{
    public class InnlineLocationRequest
    {
        public int clientId { get; set; }
        public string fromCreationDate { get; set; }
        public string toCreationDate { get; set; }
        public int skip { get; set; }
        public bool isDeleted { get; set; }
        public int take { get; set; }
    }
}
