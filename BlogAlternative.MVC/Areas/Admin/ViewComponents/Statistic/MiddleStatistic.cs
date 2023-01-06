using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogAlternative.MVC.Areas.Admin.ViewComponents.Statistic
{
    public class MiddleStatistic : ViewComponent
    {
        BlogAlternativeContext bac = new BlogAlternativeContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.lastBlog = bac.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
    }
}
