using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using User.API.Entities;
using User.API.Repositories.Users.Interfaces;

namespace User.API.Repositories.Users
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDataContext _context;

        public AccountRepository(IApplicationDataContext context)
        {
            _context = (ApplicationDataContext)(context ?? throw new ArgumentNullException(nameof(context)));
        }

        public async Task<Accounts> CreateAccount(Accounts account)
        {
            await _context.Accounts.AddAsync(account);
            _context.SaveChanges();
            return await GetAccountById(account.AccountId);
        }

        private async Task<Accounts> GetAccountById(Guid accountId)
        {
            return await _context.Accounts.Include("Users").SingleOrDefaultAsync(a => a.AccountId == accountId);
        }

        public async Task<IEnumerable<Accounts>> GetAccounts()
        {
           return await _context.Accounts.ToListAsync();
        }
    }
}
