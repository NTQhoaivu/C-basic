using System;
using System.Collections.Generic;

namespace RoleUserAppPolicy.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string? Action { get; set; }
        public string? Controller { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
