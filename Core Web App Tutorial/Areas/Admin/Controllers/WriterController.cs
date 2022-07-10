using Core_Web_App_Tutorial.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Web_App_Tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass> //Statik
        {
            new WriterClass
            {
                id = 1,
                name = "Mert",
            },
            new WriterClass
            {
                id=2,
                name="Zehra"
            },
            new WriterClass
            {
                id=3,
                name="Özlem"
            }
        };
    }
}
