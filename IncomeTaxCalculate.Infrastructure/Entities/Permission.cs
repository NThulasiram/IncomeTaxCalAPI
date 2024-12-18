using IncomeTaxCalculate.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Infrastructure.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }  // Primary Key
        public string PermissionName { get; set; }  // Permission Name (e.g., Read, Write)
        public string Description { get; set; }  // Description of the permission

        // Navigation property for the many-to-many relationship with Roles
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}

