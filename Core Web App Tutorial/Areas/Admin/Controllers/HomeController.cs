using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
