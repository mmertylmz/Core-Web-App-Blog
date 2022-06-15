using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Controllers
{
    public class WriterController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
