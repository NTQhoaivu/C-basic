using Microsoft.AspNetCore.Mvc;
using RoleUserApp.Models;
using RoleUserApp.Common;
using Microsoft.EntityFrameworkCore;

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
                    HttpContext.Session.SetString(Session.USERID, username);

                    return RedirectToAction("Index", "Users");
                }

            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove(Session.USERID);
            return RedirectToAction("Login", "Login");
        }
        public ActionResult GuestPage()
        {
            return View();
        }
    }
}
