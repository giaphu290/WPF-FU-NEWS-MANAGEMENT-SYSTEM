using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface ISystemAccountService
    {
        IEnumerable<SystemAccount> GetSystemAccounts();
        SystemAccount GetSystemAccountByID(int id);
        void InsertSystemAccount(SystemAccount systemAccount);
        void UpdateSystemAccount(SystemAccount systemAccount);
        void DeleteSystemAccount(SystemAccount systemAccount);
        SystemAccount LoginByEmail(string email, string password);
        bool AdminLogin(string email, string password);
        IEnumerable<SystemAccount> Search(string search);
        SystemAccount GetAccountWithMaxId();

    }
}
