using App.Domain.Core.Hw20.Role.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Hw20.User.Entities
{
    public class User : IdentityUser<int>
    {
        
        public string? PhoneNumber { get; set; }
        public string? NationalCode { get; set; }
        public string? Address { get; set; }
        public Role.Entities.Role? Role { get; set; }
        public int? RoleId { get; set; }
    }
}
