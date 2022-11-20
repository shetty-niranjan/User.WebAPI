using System.Collections.Generic;
using User.API.Models;
using System.Threading.Tasks;
using System;

namespace User.API.Services.User
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersResponseDto>> Users();
        Task<UsersResponseDto> UserById(Guid id);

        Task<UsersResponseDto> GetByEmailAddress(string email);

        Task<UsersResponseDto> CreateUser(UsersRequestDto user);
        Task<bool> CheckEmailAddress(string emailAddress);
    }
}
