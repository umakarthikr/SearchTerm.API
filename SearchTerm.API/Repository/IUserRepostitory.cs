using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SearchTerm.API.Entities;
using SearchTerm.API.Entities.Context;
using SearchTerm.API.Helpers;
using SearchTerm.API.Requests.Model;
using System.Net.WebSockets;

namespace SearchTerm.API.Repository
{
    public interface IUserRepostitory
    {
        Task<User> CreateAsync(User User);
        Task<User> GetUserAsync(int id);
        Task<List<User>> GetUsersAsync(string searchString);
    }

    public class UserRepository : IUserRepostitory
    {
        private UserEFCoreInMemoryDBContext _dbContext;
        public UserRepository(UserEFCoreInMemoryDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            if(_dbContext.Users.Any(x => x.Email.ToLower()== user.Email.ToLower()))
            {
                throw new AppException("User with the email '" + user.Email + "' already exists");
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user; 
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if(user == null)
                throw new AppException("User not found");

            return user;
        }

        public async Task<List<User>> GetUsersAsync(string searchString)
        {
            string searchValue = searchString.ToLower();

            var users = _dbContext.Users.Where(u => u.FirstName.ToLower().Contains(searchValue) ||
                               u.LastName.ToLower().Contains(searchValue) ||
                               u.Email.ToLower().Contains(searchValue) ||
                               u.Gender.ToLower().Contains(searchValue));

            return await users.ToListAsync();
        }
    }
 }
