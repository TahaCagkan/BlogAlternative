using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminNavbarPartial()
        {
           return PartialView();
        }
    }
}
