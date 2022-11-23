using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.API.Models;
using User.API.Services.User;
using User.API.Validate;

namespace TestProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly ILogger _logger;

        public UsersController(IUsersService userService, ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Users([FromBody] UsersRequestDto model)
        {
            var emailExist = await _userService.CheckEmailAddress(model.EmailAddress);
            IValidate<bool, string> validateEmail = new ValidateUserEmailAddress();
            var error = validateEmail.Validate(emailExist);
            if (!string.IsNullOrEmpty(error))
            {
                _logger.Error($"User cannot be created. Duplicate email address : {model.EmailAddress}");
                return BadRequest(error);
            }
            var user = await _userService.CreateUser(model);
            _logger.Information("User created successfully...");
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersResponseDto>>> Users()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Users(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                _logger.Error("User not found in the database");
                NotFound("User not found");
            }
            return Ok(user);
        }
    }
}
