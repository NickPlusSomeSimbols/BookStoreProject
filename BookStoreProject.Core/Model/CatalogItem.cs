using System;
using System.Collections.Generic;

namespace BookStoreProject.Model
{
    public class CatalogItem : BaseEntity
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
