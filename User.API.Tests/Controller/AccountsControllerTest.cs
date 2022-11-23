using AutoMapper;
using Moq;
using NUnit.Framework;
using Serilog;
using User.API.Controllers;
using User.API.Services.Account;
using User.API.Services.User;
using User.UnitTest.Service;

namespace User.UnitTest.Controller
{
    internal class AccountsControllerTest
    {
        private IAccountService _accountService;
        private IUsersService _userService;
        private Mock<ILogger> _logger;
        private Mock<IMapper> _mapper;
        private AccountsController _controller;

        [SetUp]
        public void Setup()
        {
            _accountService = new AccountsServiceFake();
            _userService = new UserServiceFake();
            _logger = new Mock<ILogger>();
            _mapper = new Mock<IMapper>();
            _controller = new AccountsController(_accountService, _userService);
        }

        [Test]
        public void Error_Message_for_user_expense_less_than_1000()
        {
            // Act
            var user = _controller.Accounts("User1@gmail.com");

            // Assert
            //Assert.IsType<BadRequestResult>(user);
        }

        //[Fact]
        //public void Create_account_for_user_expense_more_than_1000()
        //{
        //    // Act
        //    var user = _controller.Accounts("User2@gmail.com");

        //    // Assert
        //    Assert.IsType<BadRequestResult>(user);
        //}

        //[Fact]
        //public void Get_all_the_accounts()
        //{
        //    // Act
        //    var accounts = _controller.Accounts();

        //    // Assert
        //    var items = Assert.IsType<IEnumerable<UsersResponseDto>>(accounts);
        //    Assert.Equal(3, items.Count());
        //}
    }
}
