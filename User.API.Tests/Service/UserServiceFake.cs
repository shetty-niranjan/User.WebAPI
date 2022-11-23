using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Models;
using User.API.Services.User;
using User.UnitTest.Common;

namespace User.UnitTest.Service
{
    public class UserServiceFake : UserBase, IUsersService
    {
        public async Task<IEnumerable<UsersResponseDto>> GetUsers()
        {
            return await Task.FromResult(_userData);
        }

        public async Task<UsersResponseDto> GetUserById(Guid id)
        {
            return await Task.FromResult(_userData.SingleOrDefault(a => a.UserId == id));
        }

        public async Task<UsersResponseDto> GetByEmailAddress(string email)
        {
            return await Task.FromResult(_userData.SingleOrDefault(a => a.EmailAddress == email));
        }

        public async Task<UsersResponseDto> CreateUser(UsersRequestDto user)
        {
            _userData.Add(new UsersResponseDto()
            {
                UserId = Guid.NewGuid(),
                Name = user.Name,
                EmailAddress = user.EmailAddress,
                MonthlyExpenses = user.MonthlyExpenses,
                MonthlySalary = user.MonthlySalary
            });
            return await Task.FromResult(_userData.SingleOrDefault(a => a.EmailAddress == user.EmailAddress));
        }

        public async Task<bool> CheckEmailAddress(string emailAddress)
        {
            return await Task.FromResult(_userData.Any(a => a.EmailAddress == emailAddress));
        }
    }
}