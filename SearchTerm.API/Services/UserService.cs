using Microsoft.EntityFrameworkCore;
using SearchTerm.API.Entities;
using SearchTerm.API.Helpers;
using SearchTerm.API.Repository;

namespace SearchTerm.API.Services
{
    public interface IUserService 
    {
        Task<User> CreateAsync(User user);
        Task<User> GetUserAsync(int id);
        Task<List<User>> GetUsersAsync(string searchString);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepostitory _userRepository;
        private ILogger<UserService> _logger;
        public UserService(IUserRepostitory userRepostitory, ILogger<UserService> logger) 
        {
            _userRepository = userRepostitory;
            _logger = logger;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
                throw new AppException("First Name is required");

            if (string.IsNullOrEmpty(user.LastName))
                throw new AppException("Last Name is required");

            if (string.IsNullOrEmpty(user.Email))
                throw new AppException("Email is required");

            if (string.IsNullOrEmpty(user.Gender))
                throw new AppException("Gender is required");

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            if(id < 1)
                throw new AppException("Invalid Id");

            return await _userRepository.GetUserAsync(id);
        }

        public async Task<List<User>> GetUsersAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new AppException("Search string is required");

            return await _userRepository.GetUsersAsync(searchString);
        }
    }
}
