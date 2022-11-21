using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Models;
using User.API.Repositories.Users.Interfaces;

namespace User.API.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repository, IMapper mapper)
        {
            _accountRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<AccountsResponseDto> CreateAccount(UsersResponseDto model)
        {
            var account = await _accountRepository.CreateAccount(new Accounts()
            {
                AccountId = Guid.NewGuid(),
                UserId = model.UserId
            });
            return _mapper.Map<Accounts, AccountsResponseDto>(account);
        }

        public async Task<IEnumerable<AccountsResponseDto>> GetAccounts()
        {
             var accounts = await _accountRepository.GetAccounts();
            return _mapper.Map<IEnumerable<Accounts>,IEnumerable<AccountsResponseDto>>(accounts);
        }
    }
}
