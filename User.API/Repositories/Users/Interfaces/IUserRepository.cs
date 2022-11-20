using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Repositories.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<Entities.Users> UserById(Guid userId);
        Task<Entities.Users> CreateUser(Entities.Users user);
        Task<IEnumerable<Entities.Users>> Users();

        Task<bool> UserByEmailAddress(string emailAddress);

        Task<Entities.Users> GetByEmailAddress(string emailAddress);
    }
}
