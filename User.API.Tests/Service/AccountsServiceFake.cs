using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Models;
using User.API.Services.Account;
using User.API.Services.User;

namespace User.UnitTest.Service
{
    internal class AccountsServiceFake : IAccountService
    {
        private readonly List<AccountsResponseDto> _accountsData;
        private readonly List<UsersResponseDto> _userData;
        public AccountsServiceFake()
        {

            _userData = new List<UsersResponseDto>();
            _userData.Add(new UsersResponseDto()
            {
                UserId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Name = "User1",
                EmailAddress = "User1@gmail.com",
                MonthlySalary = 10000,
                MonthlyExpenses = 500
            });
            _userData.Add(
             new UsersResponseDto()
             {
                 UserId = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                 Name = "User2",
                 EmailAddress = "User2@gmail.com",
                 MonthlySalary = 11000,
                 MonthlyExpenses = 1500
             });
            _userData.Add(new UsersResponseDto()
            {
                UserId = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                Name = "User3",
                EmailAddress = "User3@gmail.com",
                MonthlySalary = 20000,
                MonthlyExpenses = 2000
            });

            _accountsData = new List<AccountsResponseDto>();
            _accountsData.Add(new AccountsResponseDto()
            {
                AccountId = new Guid("ba2bd817-98cd-4cf3-a80a-53ea0cd9c400"),
                UserId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")
            });
            _accountsData.Add(
             new AccountsResponseDto()
             {
                 AccountId = new Guid("515bd817-98cd-4cf3-a80a-53ea0cd9c400"),
                 UserId = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f")
             });
            _accountsData.Add(new AccountsResponseDto()
            {
                AccountId = new Guid("737bd817-98cd-4cf3-a80a-53ea0cd9c400"),
                UserId = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad")
            });

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
