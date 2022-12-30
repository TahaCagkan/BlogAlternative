using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.MVC.Areas.Admin.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogAlternative.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount,1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
               new BlogModel { ID=1,BlogName="C# Programlamaya Gir"},
               new BlogModel { ID=2,BlogName="Bilişim Teknolojileri üstünde araştırmalar"}
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using(var c = new BlogAlternativeContext())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    ID =x.BlogID,
                    BlogName =x.BlogTitle
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }

}

