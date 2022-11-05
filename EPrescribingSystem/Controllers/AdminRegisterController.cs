using EPrescribingSystem.Data;
using EPrescribingSystem.Extensions;
using EPrescribingSystem.Repository;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CodeStyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EPrescribingSystem.Controllers
{
    

    public class AdminRegisterController : BaseController
    {

        public bool isDone = false;
        private readonly EprescribingDBContext _context = null;
        private readonly IAccountRepository _registerRepository;

        public AdminRegisterController(EprescribingDBContext context, IAccountRepository registerRepository)
        {
            _context = context;
            _registerRepository = registerRepository;
        }

        [Route("admin-register")]
        public IActionResult Register()
        {
            UserCreateModel userCreateModel = new UserCreateModel();

            userCreateModel.RegisterUserModel = new Models.RegisterUserModel();
            List<SelectListItem> Provinces = _context.Provinces
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ProvinceID.ToString(),
                    Text = n.Name
                }).ToList();

            userCreateModel.Provinces = Provinces;
            userCreateModel.Cities = new List<SelectListItem>();

            userCreateModel.RegisterUserModel = new Models.RegisterUserModel();
            List<SelectListItem> Cities = _context.Cities
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityID.ToString(),
                    Text = n.Name
                }).ToList();

            userCreateModel.Cities = Cities;
            userCreateModel.Suburbs = new List<SelectListItem>();

            return View(userCreateModel);
        }

        //[Route("register")]
        //[HttpPost]
        //public async Task<ActionResult> Register(UserCreateModel userModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _registerRepository.CreateUserAsync(userModel);

        //        if (!result.Succeeded)
        //        {
        //            foreach (var errorMessage in result.Errors)
        //            {
        //                ModelState.AddModelError("", errorMessage.Description);
        //            }
        //        }

        //        ModelState.Clear();
        //    }

        //    return View(userModel);
        //}
		
		[Route("admin-register")]
        [HttpPost]
        public async Task<ActionResult> Register(UserCreateModel userModel)
         {
            ViewBag.Isdone = false;
            UserCreateModel userCreateModel = new UserCreateModel();

            userCreateModel.RegisterUserModel = new Models.RegisterUserModel();
            List<SelectListItem> Provinces = _context.Provinces
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ProvinceID.ToString(),
                    Text = n.Name
                }).ToList();

            userCreateModel.Provinces = Provinces;
            userCreateModel.Cities = new List<SelectListItem>();

            userCreateModel.RegisterUserModel = new Models.RegisterUserModel();
            List<SelectListItem> Cities = _context.Cities
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityID.ToString(),
                    Text = n.Name
                }).ToList();

            userCreateModel.Cities = Cities;
            userCreateModel.Suburbs = new List<SelectListItem>();

            

            if (ModelState.IsValid)
            {
                isDone = true;
                var result = await _registerRepository.CreateUserAsync(userModel);

                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description); 
                    }
                    return View(userCreateModel);
                }

                //ModelState.Clear();
                //return View(userModel);
                return RedirectToAction("AdminSuccess", "AdminRegister", new { area = "AdminRegister" });
               


                

    }
}
