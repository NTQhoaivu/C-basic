using System;
using System.Collections.Generic;

namespace RoleUserAppPolicy.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public bool? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
