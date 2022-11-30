using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogAlternative.MVC.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
			comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.BlogID = 2;
			commentManager.CommentAdd(comment);
			return PartialView();
        }
        public PartialViewResult PartialCommentListBlog(int id)
        {
            var values = commentManager.GetCommentListByID(id);
			return PartialView(values);
        }

    }
}
