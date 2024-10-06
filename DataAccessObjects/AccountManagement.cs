using BusinessObjects.Entities;
using DataAccessObjects.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace Repositories.IRepository
{
    public class AccountManagement
    {
        private static AccountManagement instance = null;
        private static readonly object instanceLock = new object();
        private AccountManagement() { }
        public static AccountManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountManagement();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<SystemAccount> GetAccountList()
        {
            List<SystemAccount> accounts = new List<SystemAccount>();
            try
            {
                var _context = new FunewsManagementFall2024Context();
                accounts = _context.SystemAccounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }
        public SystemAccount GetAccountById(int id)
        {
            SystemAccount systemAccount = null;
            try
            {
                var _context = new FunewsManagementFall2024Context();
                systemAccount = _context.SystemAccounts.SingleOrDefault(systemAccount => systemAccount.AccountId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return systemAccount;

        }
        public void AddNew(SystemAccount account)
        {
            try
            {
                SystemAccount _systemAccount = GetAccountById(account.AccountId);
                if (_systemAccount == null)
                {
                    var _context = new FunewsManagementFall2024Context();
                    _context.SystemAccounts.Add(account);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Account is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(SystemAccount account)
        {
            SystemAccount systemAccount = GetAccountById(account.AccountId);
            try
            {
                if (systemAccount != null)
                {
                    var _context = new FunewsManagementFall2024Context();
                    _context.Entry<SystemAccount>(account).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Account does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public void Remove(SystemAccount account)
        {
            try
            {
                SystemAccount systemAccount = GetAccountById(account.AccountId);
                if (systemAccount != null)
                {
                    var _context = new FunewsManagementFall2024Context();
                    _context.SystemAccounts.Remove(account);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("System account does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SystemAccount LoginByEmail(string email)
        {
            SystemAccount systemAccount = null;
            try
            {
                var _context = new FunewsManagementFall2024Context();
                systemAccount = _context.SystemAccounts.SingleOrDefault(e => e.AccountEmail.Trim().Contains(email.Trim()));
                return systemAccount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SystemAccount GetAccountWithMaxId()
        {
            SystemAccount account = null;
            try
            {
                using (var _context = new FunewsManagementFall2024Context())
                {
                    account = _context.SystemAccounts
                        .OrderByDescending(n => n.AccountId)
                        .First();
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            return account;
        }
        public IEnumerable<SystemAccount> Search(string search)
        {
            List<SystemAccount> accounts = new List<SystemAccount>();
            try
            {
                var _context = new FunewsManagementFall2024Context();
                accounts = _context.SystemAccounts.Where(a => a.AccountName.ToLower().Contains(search.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }
    }
}
