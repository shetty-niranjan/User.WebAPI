using System;
using System.Collections.Generic;
using User.API.Models;

namespace User.UnitTest.BaseClass
{
    public class AccountBase : UserBase
    {
        protected List<AccountsResponseDto> _accountsData;

        public AccountBase()
        {
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
    }
}
