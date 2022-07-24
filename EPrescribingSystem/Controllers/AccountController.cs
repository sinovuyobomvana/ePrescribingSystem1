﻿using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using EPrescribingSystem.Repository;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly EprescribingDBContext _context = null;
        private readonly IAccountRepository _accountRepository;

        public AccountController(EprescribingDBContext context, IAccountRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignUpForm()
        {

            return View();
        }

        [Route("register")]
        public IActionResult SignUpForm2()
        {
            UserCreateModel userCreateModel = new UserCreateModel();

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
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> SignUpForm2(UserCreateModel userModel)
         {

            UserCreateModel userCreateModel = new UserCreateModel();

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
                var result = await _accountRepository.CreateUserAsync(userModel);

                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description); 
                    }
                    return View(userCreateModel);
                }
                return RedirectToAction("SignIn", userModel);
                //ModelState.Clear();
            }

            return View(userCreateModel);
        }

            [HttpGet]
        public ActionResult GetSuburbs(int? CityId)
        {
            if(CityId != null)
            {
                List<SelectListItem> suburbsSel = _context.Suburbs
                .Where(s => s.CityID == CityId)
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.CityID.ToString(),
                    Text = n.Name
                }).ToList();

                return Json(suburbsSel);
            }
            return null;
        }

        [Route("signin")]
        public IActionResult SignIn()
        {

            return View();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
               var result = await _accountRepository.PasswordSignInAsync(signInModel);

                if (result.Succeeded)
                {
                    return RedirectToAction();
                }

                ModelState.AddModelError("", "Invalid Email/Password.");
            }

            return View(signInModel);
        }
    }
}
