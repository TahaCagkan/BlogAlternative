using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.BusinessLayer.ValidationRules;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.EntityLayer.Concrete;
using BlogAlternative.MVC.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogAlternative.MVC.Controllers
{

    public class WriterController : Controller
	{
        WriterManager wm = new WriterManager(new EfWriterRepository());

		[AllowAnonymous]
        public IActionResult Index()
		{
			return View();
		}

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfie()
        {
            var writerValues = wm.TGetById(1);
            return View(writerValues);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfie(Writer wr)
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
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
