using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.BusinessLayer.ValidationRules;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using FluentValidation.Results;

namespace BlogAlternative.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetListAll().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category ctgry)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult validationResults = cv.Validate(ctgry);          
            if (validationResults.IsValid)
            {
                ctgry.CategoryStatus = true;
                cm.TAdd(ctgry);
                return RedirectToAction("Index", "Category");
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

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
