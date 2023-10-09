using DataAccess.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public IEnumerable<Account> GetAccount() => AccountDAO.Instance.GetAccount();
        public Account GetAccountByUsername(string username) => AccountDAO.Instance.GetAccountByUsername(username);
        public void AddAccount(Account account) => AccountDAO.Instance.AddAccount(account);
        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
        public void DeleteAccount(Account account) => AccountDAO.Instance.DeleteAccount(account);
    }
}
