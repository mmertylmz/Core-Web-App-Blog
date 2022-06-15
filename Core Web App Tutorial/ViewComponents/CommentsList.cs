using Core_Web_App_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<CommentUser>
            {
                new CommentUser
                {
                    ID = 1,
                    Username="Mert"
                },

                new CommentUser
                {
                    ID=2,
                    Username="Zehra"
                },
                new CommentUser
                {
                    ID=3,
                    Username="Özlem"
                }
            };
            return View(commentValues);
        }
    }
}
