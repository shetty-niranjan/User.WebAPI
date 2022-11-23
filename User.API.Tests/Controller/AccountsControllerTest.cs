using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using User.API.Controllers;
using User.API.Models;
using User.API.Services.Account;
using User.API.Services.User;
using User.UnitTest.Service;
using Xunit;

namespace User.UnitTest.Controller
{
    internal class AccountsControllerTest
    {
        private readonly IAccountService _accountService;
        private readonly IUsersService _userService;
        private readonly Mock<ILogger> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly AccountsController _controller;
        public AccountsControllerTest()
        {
            _accountService = new AccountsServiceFake();
            _userService = new UserServiceFake();
            _logger = new Mock<ILogger>();
            _mapper = new Mock<IMapper>();
            _controller = new AccountsController(_accountService, _userService);
        }

        [Fact]
        public void Error_Message_for_user_expense_less_than_1000()
        {
            // Act
            var user = _controller.Accounts("User1@gmail.com");

            // Assert
            Assert.IsType<BadRequestResult>(user);
        }

        [Fact]
        public void create_account_for_user_expense_more_than_1000()
        {
            // Act
            var user = _controller.Accounts("User2@gmail.com");

            // Assert
            Assert.IsType<BadRequestResult>(user);
        }

        [Fact]
        public void get_all_the_accounts()
        {
            // Act
            var accounts = _controller.Accounts();

            // Assert
            var items = Assert.IsType<IEnumerable<UsersResponseDto>>(accounts);
            Assert.Equal(3, items.Count());
        }
    }
}
