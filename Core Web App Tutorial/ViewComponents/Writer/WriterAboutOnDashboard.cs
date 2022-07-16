using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();

        public WriterAboutOnDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var username = await _userManager.FindByNameAsync(User.Identity.Name);
            var userMail = await _userManager.FindByEmailAsync(User.Identity.Name); //need to be fix
            ViewBag.v = username;
            var writerID = c.Writers.Where(x => x.WriterMail.Equals(userMail)).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterByID(writerID);
            return View(values);
        }
    }
}
