using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.WebAPI.Controllers;
using User.API.Models;
using User.API.Services.User;
using Xunit;

namespace User.UnitTest
{
    public class UserControllerTest
    {
        private readonly UsersController _controller;
        private readonly IUsersService _service;
        private readonly Mock<ILogger> _logger;
        public UserControllerTest()
        {
            _service = new UserServiceFake();
            _logger = new Mock<ILogger>();
            _controller = new UsersController(_service, _logger.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Users() as IEnumerable<UsersResponseDto>;

            // Assert
            var items = Assert.IsType<IEnumerable<UsersResponseDto>>(okResult);
            Assert.Equal(3, items.Count());
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.Users(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result as OkObjectResult);
        }


        [Fact]
        public void GetById_Unknown_Guid_Passed_Returns_NotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Users(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

       
        [Fact]
        public void Add_Valid_User_Passed_Returns_Created_Response()
        {
            // Arrange
            UsersRequestDto request = new()
            {
                Name = "test5",
                EmailAddress="test5@gmail.com",
                MonthlyExpenses = 100,
                MonthlySalary = 1000
            };

            // Act
            var createdResponse = _controller.Users(request);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_Invalid_User_Passed_Returns_Bad_Request()
        {
            // Arrange
            UsersRequestDto request = new()
            {
                Name = "test5",
                MonthlyExpenses = 100,
                MonthlySalary = 1000
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Users(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }        
    }
}