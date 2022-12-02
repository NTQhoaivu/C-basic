using RoleUserApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RoleUserApp.Dto
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRoleDto> Roles { get; set; }

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
        public bool Status { get; set; }
    }
}
