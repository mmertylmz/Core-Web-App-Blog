
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
