using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfAllMessageRepository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
