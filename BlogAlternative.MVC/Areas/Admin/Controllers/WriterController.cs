using BlogAlternative.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BlogAlternative.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        public IActionResult AddWriter(WriterModel writerModel)
        {
            writers.Add(writerModel);
            var jsonWriters = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriters);
        }
        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                Id=1,
                Name="Ece"
            },
            new WriterModel
            {
                 Id=2,
                Name="Şahin"
            },
            new WriterModel
            {
                 Id=3,
                Name="Mert"
            },
        };
    }
}
