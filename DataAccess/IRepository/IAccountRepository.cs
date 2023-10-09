using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccount();
        Account GetAccountByUsername(string username);
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
