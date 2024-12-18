using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace IncomeTaxCalculate.Infrastructure.Entities
{
    public class UserAccessLog
    {
        public int LogId { get; set; }  // Primary Key
        public int UserId { get; set; }  // Foreign Key referencing Users
        public DateTime AccessTime { get; set; }  // Time of access
        public string IpAddress { get; set; }  // IP Address from which the user accessed
        public string Action { get; set; }  // Description of the action

        // Navigation property for the User that accessed
        public User User { get; set; }
    }
}

