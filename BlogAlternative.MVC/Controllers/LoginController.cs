using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogAlternative.MVC.Controllers
{
    public class LoginController : Controller
	{
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            BlogAlternativeContext dbContext = new BlogAlternativeContext();
            var datavalue = dbContext.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterMail)
                };
                var userIdentity = new ClaimsIdentity(claims, "admin");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                //HttpContext.Session.SetString("username", writer.WriterMail);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                
            }

            return View();
        }
    }
}
