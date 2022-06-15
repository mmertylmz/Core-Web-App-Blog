using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
