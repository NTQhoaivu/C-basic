using Microsoft.AspNetCore.Mvc;
using RoleUserAppPolicy.Models;
using RoleUserAppPolicy.Common;
using Microsoft.EntityFrameworkCore;
using RoleUserAppPolicy.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace RoleUseRoleUserAppPolicyrApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly RoleUserAppContext _context;

        public LoginController(RoleUserAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString(Session.USERNAME) != null)
            {
                HttpContext.Session.Remove(Session.USERNAME);
            }
            return View();
        }
        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            {
                var roleUserAppContext = _context.Users.Include(u => u.Group);

                var p = roleUserAppContext.ToList();
                var userDetail = p.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                var userRoleDetail = new UserDetail(userDetail);


                userRoleDetail.Roles = (from ur in _context.UserRoles
                                        join r in _context.Roles on ur.RoleId equals r.Id
                                        where ur.UserId == userDetail.Id
                                        select new UserRoleDto
                                        {
                                            Id = ur.Id,
                                            Name = r.RoleName,
                                            Action = r.Action,
                                            Controller = r.Controller,
                                            Status = (bool)ur.Status
                                        }).ToList();
                var userStr = Newtonsoft.Json.JsonConvert.SerializeObject(userRoleDetail.Roles);

                if (userDetail == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpContext.Session.SetString(Session.USERNAME, username);
                    HttpContext.Session.SetInt32(Session.USERID, userDetail.Id);
                    HttpContext.Session.SetString(Session.USERROLES, userStr);
                    // create claims



                    return RedirectToAction("Index", "Users");
                }

            }
        }
        public ActionResult Logout()
        {

            HttpContext.Session.Remove(Session.USERNAME);
            return RedirectToAction("Login", "Login");
        }
        public ActionResult GuestPage()
        {
            HttpContext.Session.Remove(Session.USERNAME);
            return View();
        }
    }
}
