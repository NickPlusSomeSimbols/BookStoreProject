using BookStoreProjectCore.Abstractions;
using BookStoreProjectCore.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectCore.Logging
{
    public class LogEntity : BaseEntity
    {
        public ApplicationUser? ApplicationUser { get; set; }
        public string? UserId { get; set; }
        public DateTime LogUploadTime { get; set; }
        public string HttpRequest { get; set; }
        public int Status { get; set; }
        public string RequestUrl { get; set; }
    }
}
