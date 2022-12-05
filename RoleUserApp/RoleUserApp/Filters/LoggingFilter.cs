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
            var userId = filterContext.HttpContext.Session.GetInt32(Session.USERID);
            if (userId != null)
            {
                //var user =  _context.Users.Find((int)userId);
                var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
                if (user == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/GuestPage");
                }
                var userRoleDetail = new UserDetail(user);


                userRoleDetail.Roles = (from ur in _context.UserRoles
                                    join r in _context.Roles on ur.RoleId equals r.Id
                                    where ur.UserId == userId
                                        select new UserRoleDto
                                    {
                                        Id = ur.Id,
                                        Name = r.RoleName,
                                        Action = r.Action,
                                        Controller = r.Controller,
                                        Status = (bool)ur.Status
                                    }).ToList();


                Console.WriteLine($"(Logging Filter)Action Executing: {filterContext.ActionDescriptor.DisplayName}");
                string ControllerName = ((ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName;
                string ActionName = ((ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName;
                string check = "0";
                foreach (var item in userRoleDetail.Roles)
                {

                    if (item.Action == ActionName && item.Controller == ControllerName)
                    {
                        check = "1";

                    }

                }
                while (ControllerName != "Login" && ActionName != "Login")
                {
                    if (check == "1")
                    {
                        base.OnActionExecuting(filterContext);
                        break;
                    }
                    else
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/GuestPage");
                        break;
                    }
                }
            }
            //else
            //{
            //    base.OnActionExecuting(filterContext);
            //}


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
