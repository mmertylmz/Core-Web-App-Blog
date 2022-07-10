using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;

using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Core_Web_App_Tutorial.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")] //Bu Route ayarlamasını yapmasaydım, pagination'da sayfa değiştirirken çakışma olduğu için farklı bir sayfaya yönlendirme yapacaktı.
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        
        public IActionResult Index(int p = 1)
        {

            var values = cm.GetList().ToPagedList(p, 3);
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category c)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(c);
            if (results.IsValid)
            {
                c.CategoryStatus = true;
                cm.TAdd(c);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
  
        }

        public IActionResult CategoryDelete(int id)
        {
            var categoryValue = cm.TGetByID(id);
            cm.TDelete(categoryValue);
            return RedirectToAction("Index", "Category");
        }
    }
}
