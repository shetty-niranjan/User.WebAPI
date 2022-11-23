using Moq;
using NUnit.Framework;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestProject.WebAPI.Controllers;
using User.API.Models;
using User.API.Services.User;
using User.UnitTest.Service;
using User.UnitTest.Common;
using User.UnitTest.BaseClass;

namespace User.UnitTest.Controller
{
    public class UserControllerTest : UserBase
    {
        private UsersController _controller;
        private  IUsersService _service;
        private  Mock<ILogger> _logger;

        [SetUp]
        public void Setup()
        {
            _service = new UserServiceFake();
            _logger = new Mock<ILogger>();
            _controller = new UsersController(_service, _logger.Object);
        }

        [Test]
        public async Task Get_All_Users()
        {
            // Act
            var okResult = await _controller.Users();
            var result = okResult.GetObjectResult();

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void Get_User_By_Id_Ok_Result()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            var expectedUser = _userData.SingleOrDefault(u => u.UserId == testGuid);

            // Act
            var okResult = _controller.Users(testGuid);
            var result = okResult.Result.GetActionObjectResult() as UsersResponseDto;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedUser.MonthlySalary, result.MonthlySalary);
                Assert.AreEqual(expectedUser.Name, result.Name);
                Assert.AreEqual(expectedUser.MonthlyExpenses, result.MonthlyExpenses);
                Assert.AreEqual(expectedUser.UserId, result.UserId);
            });
        }


        [Test]
        public void Get_User_By_Id_Failed_Result()
        {
            // Act
            var notFoundResult = _controller.Users(Guid.NewGuid());

            // Assert
            _logger.Verify(l => l.Error("User not found in the database"), Times.AtLeastOnce);
        }


        [Test]
        public void Add_Valid_User_Passed_Returns_Created_Response()
        {
            // Arrange
            UsersRequestDto request = new()
            {
                Name = "test5",
                EmailAddress = "test5@gmail.com",
                MonthlyExpenses = 100,
                MonthlySalary = 1000
            };

            // Act
            var createdResponse = _controller.Users(request);
            var result = createdResponse.Result.GetActionObjectResult() as UsersResponseDto;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(request.MonthlySalary, result.MonthlySalary);
                Assert.AreEqual(request.Name, result.Name);
                Assert.AreEqual(request.MonthlyExpenses, result.MonthlyExpenses);
                Assert.IsNotNull(result.UserId);
            });
        }

        [Test]
        public void Create_User_Invalid_Email_Address_Returns_Bad_Request()
        {
            // Arrange
            UsersRequestDto request = new()
            {
                Name = "test5",
                EmailAddress= "User1@gmail.com",
                MonthlyExpenses = 100,
                MonthlySalary = 1000
            };

            // Act
            var badResponse = _controller.Users(request);

            // Assert
            _logger.Verify(l => l.Error(It.Is<string>(s => 
                            s == $"User cannot be created. Duplicate email address : {request.EmailAddress}")),
                           Times.AtLeastOnce);

        }
    }
}