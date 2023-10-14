using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
