using BlogAlternative.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogAlternative.MVC.Areas.Admin.ViewComponents.Statistic
{
    public class MiddleSecondStatistic : ViewComponent
    {
        BlogAlternativeContext bgc = new BlogAlternativeContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = bgc.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.adminImage = bgc.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.adminDescription = bgc.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();

            return View();
        }
    }
}
