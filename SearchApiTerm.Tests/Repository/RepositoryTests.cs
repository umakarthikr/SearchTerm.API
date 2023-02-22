using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SearchTerm.API.Entities;
using SearchTerm.API.Entities.Context;
using SearchTerm.API.Repository;

namespace SearchApiTerm.Tests.Repository
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public async Task GetUsersTest_ReturnsMatchedUsers()
        {
             var options = new DbContextOptionsBuilder<UserEFCoreInMemoryDBContext>()
               .UseInMemoryDatabase(databaseName: "MockUsersDB")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new UserEFCoreInMemoryDBContext(options))
            {
                context.Users.Add(new User { Id = 1, FirstName = "James", LastName = "Arnold", Email = "j.a@email.com", Gender = "Male" });
                context.Users.Add(new User { Id = 2, FirstName = "Pauli", LastName = "Isacle", Email = "p.e@gmail.com", Gender = "Male" });
                context.Users.Add(new User { Id = 3, FirstName = "James", LastName = "Kubu", Email = "Kubu@gmail.com", Gender = "Male" });
                context.Users.Add(new User { Id = 4, FirstName = "Arnaldo", LastName = "RuoffFem", Email = "jam@email.com", Gender = "Male" });
                context.Users.Add(new User { Id = 5, FirstName = "Paula", LastName = "John", Email = "paul@email.com", Gender = "Female" });
                context.Users.Add(new User { Id = 6, FirstName = "Test", LastName = "James", Email = "Action", Gender = "Male" });
                context.SaveChanges();

                UserRepository _userRepository = new UserRepository(context);
                List<User> users = await _userRepository.GetUsersAsync("Jam");
                Assert.AreEqual(4, users.Count);

                users = await _userRepository.GetUsersAsync("Test");
                Assert.AreEqual(1, users.Count);

                users = await _userRepository.GetUsersAsync("fem");
                Assert.AreEqual(1, users.Count);
            }
        }

        [Test]
        public async Task CreateUserRepoTest_WillAddUsers()
        {
            var options = new DbContextOptionsBuilder<UserEFCoreInMemoryDBContext>()
              .UseInMemoryDatabase(databaseName: "MockUsersDB")
              .Options;

            using (var context = new UserEFCoreInMemoryDBContext(options))
            {
                //Arrange
                UserRepository _userRepository = new UserRepository(context);
                context.Users = null;
                context.Users.Add(new User { Id = 1, FirstName = "James", LastName = "Arnold", Email = "j.a@email.com", Gender = "Male" });
                context.SaveChanges();

                //Act
                User newUser = new User { Id = 2, FirstName = "New", LastName = "User", Email = "new@new.com", Gender = "Male" };
                User user = await _userRepository.CreateAsync(newUser);

                //Assert
                Assert.AreEqual(2, context.Users?.Count());
            }
        }

        [Test]
        public async Task DuplicateEmailId_Will_ThrowAnException()
        {
            var options = new DbContextOptionsBuilder<UserEFCoreInMemoryDBContext>()
              .UseInMemoryDatabase(databaseName: "MockUsersDB")
              .Options;

            using (var context = new UserEFCoreInMemoryDBContext(options))
            {
                //Arrange
                Exception caughtException = null;
                UserRepository _userRepository = new UserRepository(context);
                 context.Users = null;
                context.Users.Add(new User { Id = 1, FirstName = "James", LastName = "Arnold", Email = "new@new.com", Gender = "Male" });
                context.SaveChanges();

                //Act
                try
                {
                    User newUser = new User { Id = 2, FirstName = "New", LastName = "User", Email = "new@new.com", Gender = "Male" };
                    User user = await _userRepository.CreateAsync(newUser);
                }
                catch (Exception ex)
                {
                    caughtException = ex;
                }

                // assert
                Assert.That(caughtException, Is.Not.Null);
                Assert.That(caughtException.Message, Is.EqualTo("User with the same email already exists"));
            }
        }
    }
}
