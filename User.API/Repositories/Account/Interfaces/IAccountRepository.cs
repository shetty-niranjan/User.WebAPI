using System.Collections.Generic;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Repositories.Users.Interfaces
{
    public interface IAccountRepository
    {
        Task<Accounts> CreateAccount(Accounts account);
        Task<IEnumerable<Accounts>> GetAccounts();
    }
}
