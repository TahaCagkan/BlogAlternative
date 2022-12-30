using BlogAlternative.BusinessLayer.Concrete;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BlogAlternative.MVC.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfAllMessageRepository());

        public IActionResult InBox()
        {
            int id = 2;
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {

            var messageValue = messageManager.TGetById(id);
       
            return View(messageValue);
        }
    }
}
