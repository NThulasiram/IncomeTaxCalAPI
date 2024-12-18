using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace IncomeTaxCalculate.Infrastructure.Entities
{
    public class Role
    {
        public int RoleId { get; set; }  // Primary Key
        public string RoleName { get; set; }  // Role Name (e.g., Admin, User)
        public string Description { get; set; }  // Description of the role

        // Navigation property for the many-to-many relationship with Users
        public ICollection<UserRole> UserRoles { get; set; }

        // Navigation property for the many-to-many relationship with Permissions
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}

