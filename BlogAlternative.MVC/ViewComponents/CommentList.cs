using BlogAlternative.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogAlternative.MVC.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment> {
                new UserComment
                {
                    ID= 1,
                    UserName="Murat"
                },
                new UserComment 
                {
                    ID=2,
                    UserName="Mesut"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Merve"
                }
            };
            return View(commentValues);
        }
    }
}
