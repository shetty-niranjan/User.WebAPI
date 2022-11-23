using AutoMapper;
using Moq;
using NUnit.Framework;
using Serilog;
using User.API.Controllers;
using User.API.Helpers;
using User.API.Services.Account;
using User.API.Services.User;
using User.UnitTest.Common;
using User.UnitTest.Service;
using User.API.Models;
using System.Threading.Tasks;
using System.Linq;
using User.UnitTest.BaseClass;

namespace User.UnitTest.Controller
{
    internal class AccountsControllerTest : AccountBase
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
            _controller = new AccountsController(_accountService, _userService, _logger.Object);
        }

        [Test]
        public void Error_Message_for_user_expense_less_than_1000()
        {
            // Act
            var accountCreateResponse = _controller.Accounts("User1@gmail.com");
            var result = accountCreateResponse.Result.GetActionObjectResult() as AccountsResponseDto;

            // Assert
            _logger.Verify(l => l.Error(It.Is<string>(s =>
                            s == $"Account cannot be created. Montly expenses should be more than {ApplicationConstants.MinExpense}")),
                           Times.AtLeastOnce);
        }

        [Test]
        public void Create_account_for_user_expense_more_than_1000()
        {
            // Act
            var emailAddress = "User2@gmail.com";
            var user = _userService.GetByEmailAddress("User2@gmail.com").Result;
            var accountCreateResponse = _controller.Accounts(emailAddress);

            // Assert
            var result = accountCreateResponse.Result.GetActionObjectResult() as AccountsResponseDto;

            // Assert
            _logger.Verify(l => l.Information(It.Is<string>(s =>
                            s == $"Account create successfully for emailAddress : {emailAddress}")),
                           Times.AtLeastOnce);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result.AccountId);
                Assert.AreEqual(user.UserId, result.UserId);
            });
        }

        [Test]
        public async Task Get_all_the_accounts()
        {
            // Act
            var okResult = await _controller.Accounts();
            // Assert
            var result = okResult.GetObjectResult();
            Assert.AreEqual(_accountsData.Count, result.Count());
        }
    }
}
