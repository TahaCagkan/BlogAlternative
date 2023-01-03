using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
