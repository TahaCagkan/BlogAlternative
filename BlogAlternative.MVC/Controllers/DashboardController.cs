using BlogAlternative.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogAlternative.MVC.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            BlogAlternativeContext db = new BlogAlternativeContext();
            ViewBag.blogsCount = db.Blogs.Count().ToString();
            ViewBag.writerCount = db.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.categories = db.Categories.Count();
            return View();
        }
    }
}
