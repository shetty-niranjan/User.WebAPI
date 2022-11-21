using System.Collections.Generic;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Models;

namespace User.API.Services.Account
{
    public interface IAccountService
    {
        Task<AccountsResponseDto> CreateAccount(UsersResponseDto model);

        Task<IEnumerable<AccountsResponseDto>> GetAccounts();
    }
}
