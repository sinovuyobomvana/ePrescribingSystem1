using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EPrescribingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using EPrescribingSystem.Data;

namespace EPrescribingSystem.Controllers
{
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly EprescribingDBContext _context = null;

        public UserRolesController(EprescribingDBContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
                _context = context;
            }
        //[Route("[area]/UserRoles")]
        [Route("[area]/[controller]/[action]")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
                var users = await _userManager.Users.ToListAsync();
                var userRolesViewModel = new List<UserRolesViewModel>();
                foreach (ApplicationUser user in users)
                {
                    var thisViewModel = new UserRolesViewModel();
                    thisViewModel.UserId = user.Id;
                    thisViewModel.Email = user.Email;
                    thisViewModel.FirstName = user.FirstName;
                    thisViewModel.LastName = user.LastName;
                    thisViewModel.SuburbName = GetSuburb(user.SuburbID);
                    thisViewModel.Roles = await GetUserRoles(user);
                    userRolesViewModel.Add(thisViewModel);
                }
                return View(userRolesViewModel);
        }

        public string GetSuburb (int Id)
        {
            string suburbName;

            return suburbName = _context.Suburbs.Where(s => s.SuburbID == Id).Select(x => x.Name).FirstOrDefault();
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        //[Route("[area]/ManageUserRoles")]
        [Route("[area]/[controller]/[action]")]
        [Authorize]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }

        [HttpPost]
        //[Route("[area]/ManageUserRoles")]
        [Route("[area]/[controller]/[action]")]
        [Authorize]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            TempData["SuccessMessage"] = user.FirstName + " "+ user.LastName+    " User  Role Updated Successfully!";
            return RedirectToAction("Index");
        }

    }
}
