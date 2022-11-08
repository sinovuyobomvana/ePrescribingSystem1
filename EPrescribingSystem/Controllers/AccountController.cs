using EPrescribingSystem.Data;
using EPrescribingSystem.Models;
using EPrescribingSystem.Repository;
using EPrescribingSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EPrescribingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly EprescribingDBContext _context = null;
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(EprescribingDBContext context, IAccountRepository accountRepository, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _accountRepository = accountRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult SignUpForm()
        {

            return View();
        }

        [Route("register")]
        [HttpGet]
        public IActionResult SignUpForm2()
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

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> SignUpForm2(UserCreateModel userModel)
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

            var patientQuery = from c in _context.Users select c;
            ViewBag.IsSuccess = true;
            //ViewBag.IsDone = false;

            if (!string.IsNullOrEmpty(userModel.RegisterUserModel.IDNumber))
            {
                patientQuery = patientQuery.Where(c => c.IDNumber.Equals(userModel.RegisterUserModel.IDNumber));


                if (patientQuery.FirstOrDefault() != null)
                {
                    ViewBag.IsSuccess = false;
                    return View(userCreateModel);
                }
                else
                {

                    if (ModelState.IsValid)
                    {
                        var result = await _accountRepository.CreateUserAsync(userModel);

                        if (!result.Succeeded)
                        {
                            foreach (var errorMessage in result.Errors)
                            {
                                ModelState.AddModelError("", errorMessage.Description);
                            }
                         
                            return View(userCreateModel);
                        }
                        return RedirectToAction("Success", userModel);
                        //ModelState.Clear();
                    }
                }
            }

                return View(userCreateModel);
        }


        [HttpGet]
        public ActionResult GetCities(int? ProvinceId)
        {
            if (ProvinceId != null)
            {
                List<SelectListItem> citySel = _context.Cities
                .Where(s => s.ProvinceID == ProvinceId)
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ProvinceID.ToString(),
                    Text = n.Name
                }).ToList();

                return Json(citySel);
            }
            return null;
        }

        [HttpGet]
        public ActionResult GetPostalCodes(int? SuburbId)
        {
            if (SuburbId != null)
            {
                List<SelectListItem> suburbsSel = _context.Suburbs
                .Where(s => s.SuburbID == SuburbId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.SuburbID.ToString(),
                    Text = n.PostalCode
                }).ToList();

                return Json(suburbsSel);
            }
            return null;
        }

        [HttpGet]
        public ActionResult GetSuburbs(int? CityId)
        {
            if (CityId != null)
            {
                List<SelectListItem> suburbsSel = _context.Suburbs
                .Where(s => s.CityID == CityId)
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.SuburbID.ToString(),
                    Text = n.Name
                }).ToList();

                return Json(suburbsSel);
            }
            return null;
        }

        [Route("signin")]
        public async Task<IActionResult> SignIn()
        {
            await _accountRepository.SignOutAsync();

            return View();
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        [Route("signin")]
        [HttpPost]
      
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var userName = signInModel.Email;
                if (IsValidEmail(signInModel.Email))
                {
                    var user = await _userManager.FindByEmailAsync(signInModel.Email);
                    if (user != null)
                    {
                        userName = user.UserName;
                    }
                }

                var result = await _accountRepository.PasswordSignInAsync(signInModel);

                if (result.Succeeded)
                {
                    //Getting role by username
                    var roleUser = await _userManager.FindByNameAsync(userName);

                    HttpContext.Session.SetString("Username", signInModel.Email);

                    var userRoles = await _userManager.GetRolesAsync(roleUser);

                    foreach (var role in userRoles)
                    {
                        if (HttpContext.Session.GetString("Username") == null)
                        {
                            return RedirectToAction("SignIn");
                        }

                        if (role == "Admin")
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        else if (role == "Patient")
                            return RedirectToAction("PDashboard", "Home", new { area = "Patient" });
                        else if (role == "Doctor")
                            return RedirectToAction("Index", "Dashboard", new { area = "Doctor" });
                        else if (role == "Pharmacist")
                            return RedirectToAction("Index", "Pharmacist", new { area = "Pharmacist" });
                      

                    }
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Please check your emails and confirm your email address to login.");
                }
                else
                { 
                  ModelState.AddModelError("", "Invalid Email/Password.");
                }
            }

            return View(signInModel);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            EmailConfirmModel model = new EmailConfirmModel
            {
                Email = email
            };

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _accountRepository.ConfirmEmailAsync(uid, token);
                if (result.Succeeded)
                {
                    model.EmailVerified = true;
                }
            }
            return View(model);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        {
            var user = await _accountRepository.GetUserByEmailAsync(model.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.EmailVerified = true;
                    return View(model);
                }
                await _accountRepository.GenerateEmailConfirmationTokenAsync(user);
                model.EmailSent = true;
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong.");
            }
            return View(model);
        }

        [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountRepository.GetUserByEmailAsync(model.Email);
                if (user != null)
                {
                    await _accountRepository.GenerateForgotPasswordAsync(user);
                }

                ModelState.Clear();
                model.EmailSent = true;
            }

            return View(model);
        }
        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = uid
            };

            return View(resetPasswordModel);
        }

        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //
                model.Token = model.Token.Replace(' ', '+');

                var result = await _accountRepository.ResetPassworsAsync(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }

        //[Route("signout")]
        //There is something wrong with this thing
        public async Task<IActionResult> SignOutAsync()
        {
            await _accountRepository.SignOutAsync();
           return RedirectToAction("SignIn", "Account");
        }
    }
}
