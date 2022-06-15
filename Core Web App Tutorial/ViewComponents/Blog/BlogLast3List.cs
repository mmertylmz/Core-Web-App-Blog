using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.ViewComponents.Blog
{
    public class BlogLast3List:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        
        public IViewComponentResult Invoke()
        {
            var values = bm.GetLastThreeBlog();
            return View(values);
        }
    }
}
