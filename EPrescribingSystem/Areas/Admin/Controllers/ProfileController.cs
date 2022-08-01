using EPrescribingSystem.Models;
using EPrescribingSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chungwa.Areas.Parent.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProfileController(IAccountRepository accountRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Profile(ApplicationUser user, InputModel Input)
        {
            var user1 = await _userManager.GetUserAsync(User);

            Input.InputID = user1.Id;
            Input.FirstName = user1.FirstName;
            Input.LastName = user1.LastName;
            Input.ProfilePicture = user1.ProfilePicture;
            Input.PhoneNumber = user1.PhoneNumber;
            return View(Input);
        }

        [HttpPost]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> EditProfile(InputModel Input)
        {
            ViewBag.IsFine = false;
            var user = await _userManager.GetUserAsync(User);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);

                //if (!setPhoneResult.Succeeded)
                //{
                //    StatusMessage = "Unexpected error when trying to set phone number.";
                //    return RedirectToPage();
                //}
            }

            var firstName = user.FirstName;
            var lastName = user.LastName;

            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

           var result = await _userManager.UpdateAsync(user);
            //if(result.Succeeded)
            //{
            
            await _signInManager.RefreshSignInAsync(user);

            if(result.Succeeded)
            {
                ViewBag.IsFine = true;
            }

            //ModelState.Clear();
            //StatusMessage = "Your profile has been updated";
            return View("Profile");
        } 

        [Route("[area]/[controller]/[action]")]
        public IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePassword)
        {
            ViewBag.IsFine =false;

            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(changePassword);
                if (result.Succeeded)
                {
                    ViewBag.IsFine = true;
                    //ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View();
        }
    }
}
