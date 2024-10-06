using BusinessObjects.Entities;
using DataAccessObjects;
using DataAccessObjects.AppDbContext;
using Repositories.IRepository;

namespace Repositories.Repository
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        public void DeleteSystemAccount(SystemAccount systemAccount) => AccountManagement.Instance.Remove(systemAccount);

        public SystemAccount GetAccountWithMaxId() => AccountManagement.Instance.GetAccountWithMaxId();

        public SystemAccount GetSystemAccountByID(int id) => AccountManagement.Instance.GetAccountById(id);

        public IEnumerable<SystemAccount> GetSystemAccounts() => AccountManagement.Instance.GetAccountList();

        public void InsertSystemAccount(SystemAccount systemAccount) => AccountManagement.Instance.AddNew(systemAccount);

        public SystemAccount LoginByEmail(string email) => AccountManagement.Instance.LoginByEmail(email);

        public IEnumerable<SystemAccount> Search(string search) => AccountManagement.Instance.Search(search);

        public void UpdateSystemAccount(SystemAccount systemAccount) => AccountManagement.Instance.Update(systemAccount);
    }
}
