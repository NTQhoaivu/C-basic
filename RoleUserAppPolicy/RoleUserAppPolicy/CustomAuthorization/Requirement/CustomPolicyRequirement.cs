using Microsoft.AspNetCore.Authorization;

namespace RoleUserAppPolicy.CustomAuthorization.Requirement
{
    public class CustomPolicyRequirement : IAuthorizationRequirement
    {
        public CustomPolicyRequirement() { }
    }
}
