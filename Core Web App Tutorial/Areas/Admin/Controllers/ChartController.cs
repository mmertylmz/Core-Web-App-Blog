using Core_Web_App_Tutorial.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart() //Statik Chart 
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categoryname="Teknoloji",categorycount=10});
            list.Add(new CategoryClass { categoryname="Yazılım",categorycount=14});
            list.Add(new CategoryClass { categoryname="Spor",categorycount=5});

            return Json(new {jsonlist = list}); //jsonList ad ataması. 
        }
    }
}
