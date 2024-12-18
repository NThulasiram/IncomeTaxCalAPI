
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Infrastructure.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }  // Foreign Key referencing Users
        public int RoleId { get; set; }  // Foreign Key referencing Roles

        // Navigation properties
        public User User { get; set; }
        public Role Role { get; set; }
    }
}

