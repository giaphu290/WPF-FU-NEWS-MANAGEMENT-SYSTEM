using BusinessObjects.Entities;
using Microsoft.Extensions.Configuration;
using Repositories.IRepository;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepository _repo;
        private IConfiguration _configuration;
        public SystemAccountService(ISystemAccountRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public bool AdminLogin(string email, string password)
        {
            try
            {
                if (email.Contains(_configuration["Admin:Account"]!) && password.Contains(_configuration["Admin:Pass"]!))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {throw new Exception(ex.Message);
            }

        }

        public void DeleteSystemAccount(SystemAccount systemAccount) => _repo.DeleteSystemAccount(systemAccount);

        public SystemAccount GetAccountWithMaxId() => _repo.GetAccountWithMaxId();

        public SystemAccount GetSystemAccountByID(int id) => _repo.GetSystemAccountByID(id);

        public IEnumerable<SystemAccount> GetSystemAccounts() => _repo.GetSystemAccounts();

        public void InsertSystemAccount(SystemAccount systemAccount) => _repo.InsertSystemAccount(systemAccount);

        public SystemAccount LoginByEmail(string email, string password)
        {
            try
            {
                var a = _repo.LoginByEmail(email);
                if (a != null && a.AccountPassword == password)
                {
                    return a;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public IEnumerable<SystemAccount> Search(string search) => _repo.Search(search);

        public void UpdateSystemAccount(SystemAccount systemAccount) => _repo.UpdateSystemAccount(systemAccount);
    }
}
