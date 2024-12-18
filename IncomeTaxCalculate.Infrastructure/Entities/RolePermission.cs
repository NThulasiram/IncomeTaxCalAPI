using IncomeTaxCalculate.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Infrastructure.Entities
{
    public class RolePermission
    {
        public int RoleId { get; set; }  // Foreign Key referencing Roles
        public int PermissionId { get; set; }  // Foreign Key referencing Permissions

        // Navigation properties
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}

