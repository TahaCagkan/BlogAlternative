using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.BusinessLayer.ValidationRules;
using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.EntityLayer.Concrete;
using BlogAlternative.MVC.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace BlogAlternative.MVC.Controllers
{

    public class WriterController : Controller
	{
        WriterManager wm = new WriterManager(new EfWriterRepository());

		[Authorize]
        public IActionResult Index()
		{
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            BlogAlternativeContext bc = new BlogAlternativeContext();
            var writerName = bc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
			return View();
		}

        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            BlogAlternativeContext bc = new BlogAlternativeContext();
            var usermail = User.Identity.Name;
            var writerID = bc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writerValues = wm.TGetById(writerID);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer wr)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult result = wl.Validate(wr);
            if (result.IsValid)
            {
                wm.TUpdate(wr);
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            if(addProfileImage.WriterImage != null)
            {
                var extesion = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extesion;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = newimagename;
            }
            writer.WriterMail = addProfileImage.WriterMail;
            writer.WriterName = addProfileImage.WriterName;
            writer.WriterPassword = addProfileImage.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = addProfileImage.WriterAbout;
            wm.TAdd(writer);
            return RedirectToAction("Index","Dashboard");
        }
    }
}
