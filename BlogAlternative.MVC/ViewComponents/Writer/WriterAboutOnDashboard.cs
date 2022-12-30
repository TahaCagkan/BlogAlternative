using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogAlternative.MVC.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        BlogAlternativeContext bc = new BlogAlternativeContext();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writerID = bc.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = writerManager.GetWiterById(writerID);
            return View(values);
        }

    }
}
