using Core_Web_App_Tutorial.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core_Web_App_Tutorial.Controllers
{
    [AllowAnonymous]//Sayfayı görüntüleyebilmek için kullandığın komut.
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true); //IsPersistent verileri hatırlasın mı, LockoutOnFailure 5 defa yanlış girilince belli bir süre banlamış olacak.
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else return RedirectToAction("Index", "Login");
            }
            return View();
            
        }

        //public async Task<IActionResult> Index(Writer p)
        //{
        //    Context c = new Context();
        //    // FirstOrDefault tek değer getirmek için veya tek değer üzerinde sorgu veya işlem yapmak için kullanılan bir methottur.
        //    var dataValue = c.Writers.FirstOrDefault(x=> x.WriterMail.Equals(p.WriterMail) 
        //    && x.WriterPassword.Equals(p.WriterPassword));
        //    if(dataValue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.WriterMail)
        //        };
        //        /*Eğer string parametre girilmezse  kimlik doğrulama olmadan bir oturum başlatılıyor. 
        //         * Bu sebepten hala sistemde hiçbir sayfayı göremez halde oluyoruz. 

        //        ClaimsIdentity(IEnumerable<Claim>)	
        //        Numaralandırılmış nesne koleksiyonu kullanarak sınıfının yeni bir örneğini ClaimsIdentity Claim başlatır.

        //        ClaimsIdentity(IEnumerable<Claim>, String)	
        //        Belirtilen talepler ve kimlik doğrulama türüyle sınıfının yeni bir örneğini ClaimsIdentity başlatır.*/

        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
            
        //}
    }
}
