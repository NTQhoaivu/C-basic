using System;
using System.Collections.Generic;

namespace RoleUserAppPolicy.Models
{
    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
