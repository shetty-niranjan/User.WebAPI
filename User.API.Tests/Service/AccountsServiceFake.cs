using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Models;
using User.API.Services.Account;
using User.UnitTest.BaseClass;

namespace User.UnitTest.Service
{
    internal class AccountsServiceFake : AccountBase, IAccountService
    {
        public AccountsServiceFake()
        {
        }
        public async Task<IEnumerable<AccountsResponseDto>> GetAccounts()
        {
            return await Task.FromResult(_accountsData);
        }

        public async Task<AccountsResponseDto> CreateAccount(UsersResponseDto model)
        {
            var accountId = Guid.NewGuid();
            var user = _userData.SingleOrDefault(u => u.UserId == model.UserId);
            _accountsData.Add(new AccountsResponseDto()
            {
                AccountId = accountId,
                UserId = user.UserId
            });
            return await Task.FromResult(_accountsData.SingleOrDefault(a => a.AccountId == accountId));
        }
    }
}
