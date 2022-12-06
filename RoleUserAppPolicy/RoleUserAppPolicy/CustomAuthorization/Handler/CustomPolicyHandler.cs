using Microsoft.AspNetCore.Authorization;
using RoleUserAppPolicy.Common;
using RoleUserAppPolicy.CustomAuthorization.Requirement;

namespace RoleUserAppPolicy.CustomAuthorization.Handler
{
    public class CustomPolicyHandler : AuthorizationHandler<CustomPolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomPolicyRequirement requirement)
        {
            if (context.Resource != null)
            {
                var filterContext = (DefaultHttpContext)context.Resource;
                var httpcontext = filterContext?.HttpContext;
                var userName = httpcontext?.Session.GetString(Session.USERNAME);
                if (!string.IsNullOrEmpty(userName))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
