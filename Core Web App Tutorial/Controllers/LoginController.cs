﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Web_App_Tutorial.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous] //Sayfayı görüntüleyebilmek için kullandığın komut.
        public IActionResult Index()
        {
            return View();
        }
    }
}
