using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Areas.Admin.ViewComponents.Statistic
{
    public class GeneralStatistic:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        MessageManager msg = new MessageManager(new EfAllMessageRepository());
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.blogCount = bm.GetListAll().Count;
            ViewBag.messageCount = msg.GetListAll().Count;
            ViewBag.commentCount = cm.GetListAll().Count;
            return View();
        }
    }
}
