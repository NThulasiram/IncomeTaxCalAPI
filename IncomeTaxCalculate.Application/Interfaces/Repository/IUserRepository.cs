using IncomeTaxCalculate.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task<UserModel?> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> InsertUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> AddRoleToUserAsync(int userId, int roleId);
        Task<bool> ProvidePermissionToUserAsync(int userId, int permissionId);
    }

}
