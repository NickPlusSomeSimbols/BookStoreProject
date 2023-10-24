using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectCore.Model
{
    public class InnlineLocationRequest
    {
        int clientId { get; set; }
        string fromCreationDate { get; set; }
        string toCreationDate { get; set; }
        int skip { get; set; }
        bool isDeleted { get; set; }
        int take { get; set; }
    }
}
