using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.API.Services.User;
using User.API.Services.Account;
using AutoMapper;
using System.Collections.Generic;
using User.API.Models;
using User.API.Validate;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUsersService _userService;
        public AccountsController(
         IAccountService accountService,
         IUsersService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Accounts([FromBody] string emailAddress)
        {
            var userData = await _userService.GetByEmailAddress(emailAddress);
            IValidate<UsersResponseDto, string> validate = new ValidateUserExpenses();
            var error = validate.Validate(userData);
            if (!string.IsNullOrEmpty(error))
            {
               return BadRequest(error);
            }
            var account = await _accountService.CreateAccount(userData);
            return Ok(account);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountsResponseDto>>> Accounts()
        {
            var accounts = await _accountService.GetAccounts();
            return Ok(accounts);
        }

    }
}
