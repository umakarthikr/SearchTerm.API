using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SearchTerm.API.Entities;
using SearchTerm.API.Repository;
using SearchTerm.API.Services;

namespace SearchApiTerm.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService? _userService;
        private Mock<IUserRepostitory> _userRepositoryMock;
        private Mock<ILogger<UserService>>? _loggerMock;
        private User? _user;
        private void InitializeDependencies()
        {
            _userRepositoryMock = new Mock<IUserRepostitory>();
            _loggerMock = new Mock<ILogger<UserService>>();
            _userService = new UserService(_userRepositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task CreateUser_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            InitializeDependencies();

            _user = new User
            {
                FirstName = "Test Firstname",
                LastName = "Test Lastname",
                Email = "First.Last@email.com",
                Gender = "Male"
            };

            _userRepositoryMock?.Setup(u => u.CreateAsync(_user)).Returns(Task.FromResult<User>(_user));

            //Act
            var response = await _userService.CreateAsync(_user);

            //Assert
            Assert.IsInstanceOf(typeof(User), response);
        }


        [Test]
        public async Task CreateUserServiceMethod_WhenNoFirstNamePassed_ThrowException()
        {
            //Arrange
            InitializeDependencies();

            // arrange
            Exception caughtException = null;
            _user = new User
            {
                LastName = "James",
                Email = "ant.jam@email.com",
                Gender = "Male"
            };

            // act
            try
            {
                await _userService.CreateAsync(_user);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            // assert
            Assert.That(caughtException, Is.Not.Null);
            Assert.That(caughtException.Message, Is.EqualTo("First Name is required"));
        }
        [Test]
        public async Task CreateUserServiceMethod_WhenNoGenderPassed_ThrowException()
        {
            //Arrange
            InitializeDependencies();

            // arrange
            Exception caughtException = null;
            _user = new User
            {
                FirstName = "Test",
                LastName = "James",
                Email = "ant.jam@email.com",
                Gender = ""
            };

            // act
            try
            {
                await _userService.CreateAsync(_user);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            // assert
            Assert.That(caughtException, Is.Not.Null);
            Assert.That(caughtException.Message, Is.EqualTo("Gender is required"));
        }

        [Test]
        public async Task CreateUserServiceMethod_WhenNoEmailPassed_ThrowException()
        {
            //Arrange
            InitializeDependencies();

            // arrange
            Exception caughtException = null;
            _user = new User
            {
                FirstName= "Test",
                LastName = "James",
                Gender = "Male"
            };

            // act
            try
            {
                await _userService.CreateAsync(_user);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            // assert
            Assert.That(caughtException, Is.Not.Null);
            Assert.That(caughtException.Message, Is.EqualTo("Email is required"));
        }

        [Test]
        public async Task CreateUserServiceMethod_WhenLastNameNotPassed_ThrowException()
        {
            //Arrange
            InitializeDependencies();

            // arrange
            Exception caughtException = null;
            _user = new User
            {
                FirstName= "Test",
                LastName = "",
                Email = "ant.jam@email.com",
                Gender = "Male"
            };

            // act
            try
            {
                await _userService.CreateAsync(_user);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            // assert
            Assert.That(caughtException, Is.Not.Null);
            Assert.That(caughtException.Message, Is.EqualTo("Last Name is required"));
        }

        [Test]
        public async Task CreateUserServiceMethod_WhenNoEmailNamePassed_ThrowException()
        {
            //Arrange
            InitializeDependencies();

            // arrange
            Exception caughtException = null;
            _user = new User
            {
                LastName = "James",
                Email = "ant.jam@email.com",
                Gender = "Male"
            };

            // act
            try
            {
                await _userService.CreateAsync(_user);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            // assert
            Assert.That(caughtException, Is.Not.Null);
            Assert.That(caughtException.Message, Is.EqualTo("First Name is required"));
        }

        [Test]
        public async Task GetUserServiceMethod_WhenIvalidPassed_ThrowException()
        {
            //Arrange
            InitializeDependencies();

            // arrange
            Exception caughtException = null;

            // act
            try
            {
                await _userService.GetUserAsync(0);
            }
            catch (Exception ex)
            {
                caughtException = ex;
            }

            // assert
            Assert.That(caughtException, Is.Not.Null);
            Assert.That(caughtException.Message, Is.EqualTo("Invalid Id"));
        }

        [Test]
        public async Task SearchUserServiceMethod_whenCalled_ReturnsMatchingUser()
        {
            //Arrange
            InitializeDependencies();

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

            _userRepositoryMock?.Setup(u => u.CreateAsync(_user)).Returns(Task.FromResult<User>(_user));
            _userRepositoryMock?.Setup(u => u.GetUsersAsync(It.IsAny<string>())).Returns(Task.FromResult<List<User>>(matchingUsers));

            //Act
            var createUser = await _userService.CreateAsync(_user);
            var response = await _userService.GetUsersAsync("James");

            //Assert
            Assert.IsInstanceOf(typeof(List<User>), response);
        }
    }
}
