using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class Product
    {
        public int Productid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public string Type { get; set; }
    }
}
