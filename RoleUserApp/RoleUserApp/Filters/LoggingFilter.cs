using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using RoleUserApp.Common;
using RoleUserApp.Dto;
using RoleUserApp.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace RoleUserApp.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        private readonly RoleUserAppContext _context;

        public LoggingFilter(RoleUserAppContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString(Session.USERNAME) != null)
            {
                var userRoles = filterContext.HttpContext.Session.GetString(Session.USERROLES);
                var user = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserRoleDto>>(userRoles);

                if (user == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/GuestPage");
                }



                string ControllerName = ((ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName;
                string ActionName = ((ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName;
                var userDetail = user.Where(x => x.Controller == ControllerName && x.Action == ActionName).FirstOrDefault();

                if (userDetail != null)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    filterContext.HttpContext.Response.Redirect("/login/guestpage");
                }

            }


        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                Console.WriteLine("(Logging Filter)Exception thrown");
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
