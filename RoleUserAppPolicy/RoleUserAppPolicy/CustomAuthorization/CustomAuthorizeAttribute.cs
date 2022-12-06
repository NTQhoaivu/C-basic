using Microsoft.AspNetCore.Authorization;

namespace RoleUserAppPolicy.CustomAuthorization
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(string permission)
        {
            Policy = permission;
        }
    }
}
