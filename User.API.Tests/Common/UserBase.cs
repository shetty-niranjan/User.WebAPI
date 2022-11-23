using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.API.Models;

namespace User.UnitTest.Common
{
    public class UserBase
    {
        protected List<UsersResponseDto> _userData;
        public UserBase()
        {
            _userData = new List<UsersResponseDto>
            {
                new UsersResponseDto()
                {
                    UserId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "User1",
                    EmailAddress = "User1@gmail.com",
                    MonthlySalary = 10000,
                    MonthlyExpenses = 500
                },
                new UsersResponseDto()
                {
                    UserId = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "User2",
                    EmailAddress = "User2@gmail.com",
                    MonthlySalary = 11000,
                    MonthlyExpenses = 1500
                },
                new UsersResponseDto()
                {
                    UserId = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "User3",
                    EmailAddress = "User3@gmail.com",
                    MonthlySalary = 20000,
                    MonthlyExpenses = 2000
                }
            };
        }

    }
}
