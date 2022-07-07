using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }
    }
}
