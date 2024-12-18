using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncomeTaxCalculate.Domain.Model
{
    public class UserModel
    {
        [JsonIgnore]
        public int UserId { get; set; }  // Primary Key
        public string Username { get; set; }  // Unique Username
        public string Email { get; set; }  // Unique Email
        //[JsonIgnore]
        public string Password { get; set; }  // Password Hash
        public string FirstName { get; set; }  // First Name
        public string LastName { get; set; }  // Last Name
        public bool IsActive { get; set; }  // Active/Inactive Flag
        //[JsonIgnore]
        public DateTime CreatedAt { get; set; }  // Account creation timestamp
        public DateTime? UpdatedAt { get; set; }

    }

}

