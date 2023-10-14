using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class Order
    {
        public int Orderid { get; set; }
        public string Username { get; set; }
        public DateTime Orderdate { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public decimal Totalprice { get; set; }

        public virtual Account UsernameNavigation { get; set; }
    }
}
