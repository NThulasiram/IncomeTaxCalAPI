using IncomeTaxCalculate.Application.Interfaces;
using IncomeTaxCalculate.Application.Interfaces.Repository;
using IncomeTaxCalculate.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Get user by ID and return a UserModel
        public async Task<UserModel?> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user != null)
            {
                // Map User to UserModel (assumes ToUserModel() is an extension method or separate method for mapping)
                return user;
            }
            return null;
        }

        public async Task<UserModel?> GetUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user != null)
            {
                // Map User to UserModel (assumes ToUserModel() is an extension method or separate method for mapping)
                return user;
            }
            return null;
        }

        public async Task<UserModel?> InsertUserAsync(UserModel userDto)
        {
            if(userDto !=null)
            {
                userDto.Password = HashPassword(userDto.Password);
                userDto.CreatedAt = DateTime.Now;
            }
            var user = await _userRepository.InsertUserAsync(userDto);
            if (user != null)
            {
                // Map User to UserModel (assumes ToUserModel() is an extension method or separate method for mapping)
                return user;
            }
            return null;
        }

        public async Task<UserModel> ValidateUserAsync(string username, string password)
        {
            // Retrieve the user from the database
            var user = await _userRepository.GetUserByUserNameAsync(username);
            if (user == null) return null;

            // Hash the input password and compare it to the stored hash
            var hashedPassword = HashPassword(password);
            if (user.Password == hashedPassword)
            {
                return user; // Valid credentials
            }

            return null; // Invalid credentials
        }

        // Helper method to hash passwords (use SHA256 for simplicity here)
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }


    }
}
