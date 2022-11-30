using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.BusinessLayer.ValidationRules;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
			WriterValidator validatorRule = new WriterValidator();
			ValidationResult validationResults = validatorRule.Validate(writer);
			if(validationResults.IsValid)
			{
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                writerManager.TAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
			else
			{
				foreach (var item in validationResults.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
			
        }
    }
}
