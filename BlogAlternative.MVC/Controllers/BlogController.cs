using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.BusinessLayer.ValidationRules;
using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogAlternative.MVC.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogAlternativeContext bc = new BlogAlternativeContext();

        //Index sayfası
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        //blog id ye göre detay listeleme
        public IActionResult BlogDetails(int id)
        {
            ViewBag.infoComment = id;
            var values = bm.GetBlogListByID(id);
            return View(values);
        }
        //admin palenli blogların listelenmesi
        public ActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var writerID = bc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //kategori isimlerinin getirilmesi
            var values = bm.GetListWithCategoryByWriterID(writerID);
            return View(values);
        }
        //ekleme get
        [HttpGet]
        public ActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryVal = categoryValues;
            return View();
        }
        //ekleme Post
        [HttpPost]
        public ActionResult BlogAdd(Blog blog)
        {
            var usermail = User.Identity.Name;
            var writerID = bc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator validatorRule = new BlogValidator();
            ValidationResult validationResults = validatorRule.Validate(blog);
            if (validationResults.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
                blog.WriterID = writerID;
                bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //Silme işlemi
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = bm.TGetById(id);
            bm.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {

            var blogValue = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryVal = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {

            var usermail = User.Identity.Name;
            var writerID = bc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID = writerID;
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
