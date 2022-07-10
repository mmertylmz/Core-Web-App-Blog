using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic2:ViewComponent
    {
        Context c = new Context(); 
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.WriterID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
    }
}
