using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace IncomeTaxCalculate.Infrastructure.Entities
{
    public class User
    {
        public int UserId { get; set; }  // Primary Key
        public string Username { get; set; }  // Unique Username
        public string Email { get; set; }  // Unique Email
        public string PasswordHash { get; set; }  // Password Hash
        public string FirstName { get; set; }  // First Name
        public string LastName { get; set; }  // Last Name
        public bool IsActive { get; set; }  // Active/Inactive Flag
        public DateTime CreatedAt { get; set; }  // Account creation timestamp
        public DateTime? UpdatedAt { get; set; }  // Timestamp for last update

        // Navigation property for the many-to-many relationship with Roles
        public ICollection<UserRole> UserRoles { get; set; }

        // Navigation property for access logs (if you are using the UserAccessLog table)
        public ICollection<UserAccessLog> UserAccessLogs { get; set; }
    }
}

