using IncomeTaxCalculate.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task<UserModel?> InsertUserAsync(UserModel userDto);
        Task<UserModel> ValidateUserAsync(string username, string password);

    }
}
