using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ISystemAccountRepository 
    {
        IEnumerable<SystemAccount> GetSystemAccounts();
        SystemAccount GetSystemAccountByID(int id);
        void InsertSystemAccount(SystemAccount systemAccount);
        void UpdateSystemAccount(SystemAccount systemAccount);
        void DeleteSystemAccount(SystemAccount systemAccount);
        SystemAccount LoginByEmail(string email);
        IEnumerable<SystemAccount> Search(string search);
        SystemAccount GetAccountWithMaxId();

    }
}
