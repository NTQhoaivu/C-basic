using Microsoft.AspNetCore.Authorization;
using RoleUserAppPolicy.Common;
using RoleUserAppPolicy.CustomAuthorization.Requirement;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using RoleUserAppPolicy.Dto;
using RoleUserAppPolicy.Models;

namespace RoleUserAppPolicy.CustomAuthorization.Handler
{
    public class CustomPermissionHandler : AuthorizationHandler<CustomPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomPermissionRequirement requirement)
        {
            var filterContext = (DefaultHttpContext)context.Resource;
            var httpcontext = filterContext?.HttpContext;
            var userRoleStr = httpcontext?.Session.GetString(Session.USERROLES);
            var userRoles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserRoleDto>>(userRoleStr);
            var isAllowAccess = userRoles.ToList().Where(x => x.Controller==requirement.Function&&x.Action==requirement.Action).FirstOrDefault();
            if (isAllowAccess!=null)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
