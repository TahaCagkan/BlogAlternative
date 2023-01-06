using BlogAlternative.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogAlternative.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel { 
                categoryname="Yazılım",
                categorycount=10,
            });
            list.Add(new CategoryModel
            {
                categoryname = "Proje Yönetimi",
                categorycount = 5,
            });
            list.Add(new CategoryModel
            {
                categoryname = "İş Analistliği",
                categorycount = 7,
            });
            return Json(new {jsonlist=list });
        }
    }
}
