using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
