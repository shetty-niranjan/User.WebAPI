using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.API.Services.User;
using User.API.Services.Account;
using System.Collections.Generic;
using User.API.Models;
using User.API.Validate;
using User.API.Helpers;
using Serilog;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUsersService _userService;
        private readonly ILogger _logger;
        public AccountsController(
         IAccountService accountService,
         IUsersService userService, ILogger logger)
        {
            _accountService = accountService;
            _userService = userService;
            _logger = logger;
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
                _logger.Error($"Account cannot be created. Montly expenses should be more than {ApplicationConstants.MinExpense}");
                return BadRequest(error);
            }
            var account = await _accountService.CreateAccount(userData);
            _logger.Information($"Account create successfully for emailAddress : {emailAddress}");
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
