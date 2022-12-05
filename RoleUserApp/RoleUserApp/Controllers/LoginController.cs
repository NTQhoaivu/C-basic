using Microsoft.AspNetCore.Mvc;
using RoleUserApp.Models;
using RoleUserApp.Common;
using Microsoft.EntityFrameworkCore;
using RoleUserApp.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace RoleUserApp.Controllers
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
            HttpContext.Session.Remove(Session.USERNAME);
            return View();
        }
        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            {
                var roleUserAppContext = _context.Users.Include(u => u.Group);

                var p = roleUserAppContext.ToList();
                var userDetail = p.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();




                if (userDetail == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    HttpContext.Session.SetString(Session.USERNAME, username);
                    HttpContext.Session.SetInt32(Session.USERID, userDetail.Id);

                    // create claims
                    List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                };

                    // create identity
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

                    // create principal
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    //// sign-in
                    await HttpContext.SignInAsync(
                            scheme: "DemoSecurityScheme",
                            principal: principal,
                            properties: new AuthenticationProperties
                            {
                                //IsPersistent = true, // for 'remember me' feature
                                //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                            });


                    return RedirectToAction("Index", "Users");
                }

            }
        }
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(
           scheme: "DemoSecurityScheme");
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
