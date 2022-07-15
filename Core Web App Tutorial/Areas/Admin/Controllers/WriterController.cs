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

        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.id.Equals(writerid));
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult WriterAdd(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
            
        }

        public IActionResult WriterDelete(int id)
        {
            var writer = writers.FirstOrDefault(x => x.id.Equals(id));
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult WriterUpdate(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.id.Equals(w.id));
            writer.name = w.name;
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass> //Static
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
