using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminID.Equals(1)).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID.Equals(1)).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminID.Equals(1)).Select(y => y.SDescription).FirstOrDefault();
            return View();
        }
    }
}
