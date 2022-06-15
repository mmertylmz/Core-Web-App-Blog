using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = am.GetList();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
