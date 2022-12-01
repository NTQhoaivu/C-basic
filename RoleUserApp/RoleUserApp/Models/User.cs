using System;
using System.Collections.Generic;

namespace RoleUserApp.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? GroupId { get; set; }
        public bool? Status { get; set; }
        public string? BirthDay { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public bool? Gender { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
