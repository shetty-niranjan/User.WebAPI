using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Models;
using User.API.Services.User;

namespace User.UnitTest
{
    public class UserServiceFake : IUsersService
    {
        private readonly List<UsersResponseDto> _userData;
        public UserServiceFake()
        {
            _userData = new List<UsersResponseDto>();
            _userData.Add(new UsersResponseDto() { UserId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Name = "User1", EmailAddress = "User1@gmail.com", MonthlySalary = 10000, MonthlyExpenses = 500 });
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
          
        }

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