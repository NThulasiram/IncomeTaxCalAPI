using IncomeTaxCalculate.Domain.Model;
using IncomeTaxCalculate.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Infrastructure.Mapper
{
    public static class UserMapper
    {
        public static UserModel ToUserModel(this User user)
        {
            return new UserModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = user.PasswordHash,
                //UserRole = user.UserRoles?.Select(ur => ur.Role.RoleName).ToList() ?? new List<string>(),
                //Permissions = user.UserRoles?
                //    .SelectMany(ur => ur.Role.RolePermissions.Select(rp => rp.Permission.PermissionName))
                //    .Distinct()
                //    .ToList() ?? new List<string>()
            };
        }

        public static User ToUserEntity(this UserModel model, User? existingEntity = null)
        {
            // If an existing entity is provided, update it; otherwise, create a new one.
            var user = existingEntity ?? new User();

            user.UserId = model.UserId;
            user.Username = model.Username;
            user.Email = model.Email;
            user.PasswordHash = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.CreatedAt = model.CreatedAt;
            user.UpdatedAt = model.UpdatedAt;
            // Map Roles
            //if (model.Roles != null && model.Roles.Any())
            //{
            //    user.UserRoles = model.Roles.Select(roleName => new UserRole
            //    {
            //        Role = new Role { RoleName = roleName } // Assuming roles are validated/created elsewhere
            //    }).ToList();
            //}

            return user;
        }
    }

}
