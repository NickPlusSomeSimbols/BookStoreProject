using BookStoreProjectCore.Abstractions;
using BookStoreProjectCore.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectCore.Logging
{
    public class LogTable : BaseEntity
    {
        public ApplicationUser? ApplicationUser { get; set; }
        public string LogUploadTime { get; set; }
        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }
        public int Status { get; set; }
        public string RequestPath { get; set; }
    }
}
