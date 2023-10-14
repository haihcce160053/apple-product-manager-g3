using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }

        public virtual AccountType TypeNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
