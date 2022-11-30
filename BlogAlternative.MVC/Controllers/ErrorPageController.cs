using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult ErrorFault(int code)
		{
			return View();
		}
	}
}
