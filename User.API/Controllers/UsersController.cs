using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.API.Entities;
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
        public async Task<ActionResult<UsersResponseDto>> Users([FromBody] UsersRequestDto model)
        {
            _logger.Information("User creation started for email address...");
            var emailExist = await _userService.CheckEmailAddress(model.EmailAddress);
            IValidate<bool, string> validateEmail = new ValidateUserEmailAddress();
            var error = validateEmail.Validate(emailExist);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var user = await _userService.CreateUser(model);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersResponseDto>>> Users()
        {
            var users = await _userService.Users();           
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Users(Guid id)
        {
            var user = await _userService.UserById(id);
            if (user == null) NotFound("User not found");
            return Ok(user);
        }
    }
}
