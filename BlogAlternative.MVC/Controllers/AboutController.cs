using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var values = aboutManager.GetListAll();
            return View(values);
		}
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
