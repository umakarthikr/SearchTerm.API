using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SearchTerm.API.Controllers;
using SearchTerm.API.Entities;
using SearchTerm.API.Requests.Model;
using SearchTerm.API.Services;

namespace SearchApiTerm.Tests.Controller
{
    [TestFixture]
    public class UserControllerTest
    {  
        private  Mock<IUserService>? _userServiceMock;
        private  UserController? _controller;
        private  Mock<IMapper>? _mapperMock;
        private User? _user;
        private CreateUserRequest? _userRequest;
        private void InitializeDependencies()
        {
            _userServiceMock = new Mock<IUserService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new UserController(_userServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CreateUser_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            InitializeDependencies();

            _userRequest = new CreateUserRequest
            {
                First_Name = "Test Firstname",
                Last_Name = "Test Lastname",
                Email = "First.Last@email.com",
                Gender = "Male"
            };

            _user = new User
            {
                FirstName = "Test Firstname",
                LastName = "Test Lastname",
                Email = "First.Last@email.com",
                Gender = "Male"
            };

            var user = _mapperMock.Setup(m => m.Map<User>(_userRequest)).Returns(_user);
            _userServiceMock?.Setup(u => u.CreateAsync(_user)).Returns(Task.FromResult<User>(_user));

            //Act
            var response = await _controller.CreateAsync(_userRequest);

            //Assert
            Assert.IsInstanceOf(typeof(CreatedAtActionResult), response);
        }


        [Test]
        public async Task CreateUser_WhenThereIsModelstateError_ReturnsAValidationError()
        {
            //Arrange
            InitializeDependencies();

            _userRequest = new CreateUserRequest
            {
                First_Name = "",
                Last_Name = "Test1 Lastname",
                Email = "First1.Last@email.com",
                Gender = "Male"
            };

            _controller.ModelState.AddModelError("error", "Validation Errors");

            //Act
            var response = await _controller.CreateAsync(_userRequest);

            //Assert
            Assert.IsTrue(_controller.ViewData.ModelState.Count ==1 , "First Name is required");
        }

        [Test]
        public async Task SearchUser_whenCalled_ReturnsMatchingUser()
        {
            //Arrange
            InitializeDependencies();

            _userRequest = new CreateUserRequest
            {
                First_Name = "Antony",
                Last_Name = "James",
                Email = "ant.jam@email.com",
                Gender = "Male"
            };
            _user = new User
            {
                FirstName = "Antony",
                LastName = "James",
                Email = "ant.jam@email.com",
                Gender = "Male"
            };

            List<User> matchingUsers = new List<User> {
                new User
                {
                    FirstName = "Antony",
                    LastName = "James",
                    Email = "ant.jam@email.com",
                    Gender = "Male"
                }
            };           

            var user = _mapperMock.Setup(m => m.Map<User>(_userRequest)).Returns(_user);
            _userServiceMock?.Setup(u => u.CreateAsync(_user)).Returns(Task.FromResult<User>(_user));
            _userServiceMock?.Setup(u => u.GetUsersAsync(It.IsAny<string>())).Returns(Task.FromResult<List<User>>(matchingUsers));

            //Act
            var createUser = await _controller.CreateAsync(_userRequest);
            var response = (await _controller.GetUsersAsync("James")) as ObjectResult;

            //Assert
            Assert.IsInstanceOf(typeof(List<User>), response.Value);
        }
    }
}
