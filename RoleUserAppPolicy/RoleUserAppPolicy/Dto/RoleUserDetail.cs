using RoleUserAppPolicy.Models;
using System.ComponentModel.DataAnnotations;

namespace RoleUserAppPolicy.Dto
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRoleDto>? Roles { get; set; }

        public UserDetail() { }
        public UserDetail(User user)
        {
            Id = user.Id;
            Name = user.UserName;
        }
    }

    public class UserRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool Status { get; set; }
    }
}
