using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
