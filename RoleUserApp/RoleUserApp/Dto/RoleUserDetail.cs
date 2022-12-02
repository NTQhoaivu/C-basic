using System.ComponentModel.DataAnnotations;

namespace RoleUserApp.Dto
{
    public class RoleUserDetail
    {

        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string roleName { get; set; }
        public bool status { get; set; }
    }
}
