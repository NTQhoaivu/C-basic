using Microsoft.AspNetCore.Authorization;

namespace RoleUserAppPolicy.CustomAuthorization.Requirement
{
    public class CustomPermissionRequirement : IAuthorizationRequirement
    {
        public string Function { get; private set; }
        public string Action { get; private set; }

        public CustomPermissionRequirement(string function, string action)
        {
            Function = function;
            Action = action;
        }
    }
}
