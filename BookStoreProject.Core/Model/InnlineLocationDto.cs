using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectCore.Model
{
    public class InnlineLocationDto
    {
        public int ClientId { get; set; }
        public int TypeId { get; set; }
        public int PointTypeId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
