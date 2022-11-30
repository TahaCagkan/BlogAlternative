using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}