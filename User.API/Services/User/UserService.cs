using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Models;
using User.API.Repositories.Users.Interfaces;

namespace User.API.Services.User
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<UsersResponseDto> CreateUser(UsersRequestDto userModel)
        {
            var user = _mapper.Map<Users>(userModel);
            return _mapper.Map<Users,UsersResponseDto>(await _repository.CreateUser(user));
        }

        public async Task<IEnumerable<UsersResponseDto>> Users()
        {
            var users = await _repository.Users();
            return _mapper.Map<IEnumerable<Users>, IEnumerable<UsersResponseDto>>(users);
        }

        public async Task<UsersResponseDto> UserById(Guid id)
        {
            var userById = await _repository.UserById(id);
            if (userById == null) return null;
            return _mapper.Map<Users, UsersResponseDto>(userById);
        }

        public async Task<bool> CheckEmailAddress(string emailAddress)
        {
            var userByEmail = await _repository.UserByEmailAddress(emailAddress);
            return userByEmail;
        }

        public async Task<UsersResponseDto> GetByEmailAddress(string email)
        {
            var user = await _repository.GetByEmailAddress(email);
            return _mapper.Map<Users, UsersResponseDto>(user); ;
        }
    }
}
