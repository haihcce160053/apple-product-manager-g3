using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();

        public AccountDAO() 
        { 
        
        }

        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAccount()
        {
            List<Account> account;
            try
            {
                var myStockDB = new AppleProductManagerContext();
                account = myStockDB.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public Account GetAccountByUsername(string username)
        {
            Account account = null;
            try
            {
                var myStockDB = new AppleProductManagerContext();
                account = myStockDB.Accounts.SingleOrDefault(account => account.Username == username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public void AddAccount(Account account)
        {
            try
            {
                Account _account = GetAccountByUsername(account.Username);
                if (_account == null)
                {
                    var myStockDB = new AppleProductManagerContext();
                    myStockDB.Accounts.Add(account);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not add account");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                Account _account = GetAccountByUsername(account.Username);
                if (_account != null)
                {
                    var myStockDB = new AppleProductManagerContext();
                    myStockDB.Entry<Account>(account).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Account does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteAccount(Account account)
        {
            try
            {
                Account _car = GetAccountByUsername(account.Username);
                if (_car != null)
                {
                    var myStockDB = new AppleProductManagerContext();
                    myStockDB.Accounts.Remove(account);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not delete this account");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsUserNameExists(string username, string email)
        {
            using (var context = new AppleProductManagerContext())
            {
                return context.Accounts.Any(m => m.Username == username || m.Email == email);
            }
        }

        public List<Account> SearchAccByUsername(string proName)
        {
            try
            {
                var context = new AppleProductManagerContext();
                List<Account> pro = context.Accounts
                    .Where(p => p.Username.Contains(proName)).ToList();
                return pro;
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred!");
            }
        }
    }
}
