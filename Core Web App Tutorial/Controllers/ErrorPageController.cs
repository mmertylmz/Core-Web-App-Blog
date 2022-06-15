using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {

            return View();
        }
    }
}
