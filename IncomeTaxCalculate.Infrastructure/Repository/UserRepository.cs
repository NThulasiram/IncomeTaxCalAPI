using IncomeTaxCalculate.Application.Interfaces.Repository;
using IncomeTaxCalculate.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeTaxCalculate.Domain.Model;
using IncomeTaxCalculate.Infrastructure.Mapper;

namespace IncomeTaxCalculate.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get user by ID
        public async Task<UserModel?> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            if (user != null) { return user.ToUserModel(); } else { return null; }
        }

        // Get user by ID
        public async Task<UserModel?> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _context.Users
             .Include(u => u.UserRoles)
                 .ThenInclude(ur => ur.Role)
             .ThenInclude(r => r.RolePermissions)
                 .ThenInclude(rp => rp.Permission)
                 .FirstOrDefaultAsync(x=>x.Username== userName);
            
                if (user != null) { return user.ToUserModel(); } else { return null; }
            }
            catch (Exception ex) 
            {
            return null;
            }
         
        }

        // Get all users
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var userModels = new List<UserModel>();
            var users = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .ToListAsync();

            if (users.Any())
            {
                foreach (var user in users)
                {
                    userModels.Add(user.ToUserModel());
                }
            }
            return null;
        }

        // Insert a new user
        public async Task<UserModel> InsertUserAsync(UserModel userDto)
        {
           try
            {
                _context.Users.Add(userDto.ToUserEntity());
                await _context.SaveChangesAsync();
            } 
            catch (Exception ex) 
            {
            }
        
            return userDto;
        }

        // Update a user
        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser == null) throw new ArgumentException("User not found");

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            // Update other fields as needed
            _context.Entry(existingUser).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return existingUser.ToUserModel();
        }

        // Delete a user
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // Add role to a user
        public async Task<bool> AddRoleToUserAsync(int userId, int roleId)
        {
            var user = await _context.Users.FindAsync(userId);
            var role = await _context.Roles.FindAsync(roleId);

            if (user == null || role == null) return false;

            if (!_context.UserRoles.Any(ur => ur.UserId == userId && ur.RoleId == roleId))
            {
                _context.UserRoles.Add(new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                });
                await _context.SaveChangesAsync();
            }

            return true;
        }

        // Provide a permission to a user (indirectly via roles)
        public async Task<bool> ProvidePermissionToUserAsync(int userId, int permissionId)
        {
            var user = await GetUserEntityByIdAsync(userId);
            var permission = await _context.Permissions.FindAsync(permissionId);

            if (user == null || permission == null) return false;

            var rolePermission = _context.RolePermissions.FirstOrDefault(rp => rp.PermissionId == permissionId);

            if (rolePermission == null) return false;

            if (!user.UserRoles.Any(ur => ur.RoleId == rolePermission.RoleId))
            {
                _context.UserRoles.Add(new UserRole
                {
                    UserId = userId,
                    RoleId = rolePermission.RoleId
                });

                await _context.SaveChangesAsync();
            }

            return true;
        }

        private async Task<User?> GetUserEntityByIdAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.UserId == userId);
           return user;
        }

    }
}
