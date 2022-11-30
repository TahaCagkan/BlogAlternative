using Microsoft.AspNetCore.Mvc;

namespace BlogAlternative.MVC.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke( )
        {
           
            return View();
        }
    }
}
