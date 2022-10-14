using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
