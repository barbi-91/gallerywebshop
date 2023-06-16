using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Areas.Identity.Models;
using GalleryWebShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace GalleryWebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public AdminController(UserManager<ApplicationUser> usrMgr, RoleManager<IdentityRole> roleMgr, ApplicationDbContext dbContext)
        {
            _userManager = usrMgr;
            _roleManager = roleMgr;
            _dbContext = dbContext;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            var userRole = _dbContext.Users
                .Join
                    (
                        _dbContext.UserRoles,
                        u => u.Id,
                        ur => ur.UserId,
                        (u, ur) => new { u.Email, u.FirstName, u.LastName, u.UserName, u.Address, u.EmailConfirmed, ur.RoleId, ur.UserId}
                    )
               .Join
                    (
                        _dbContext.Roles,
                        ur => ur.RoleId,
                        r => r.Id,
                        (ur, r) => new User{ Email= ur.Email, FirstName = ur.FirstName, LastName = ur.LastName, UserName = ur.UserName, Type = r.Name, Address = ur.Address, EmailConfirmed = ur.EmailConfirmed, UserId = ur.UserId }
                    );
                   

            return View(userRole);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? "";
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                ViewBag.Roles = _roleManager.Roles.ToList();
                if (ModelState.IsValid)
                {
                    ApplicationUser appUser = new ApplicationUser()
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName= user.FirstName,
                        LastName= user.LastName,
                        Address= user.Address,
                        EmailConfirmed = user.EmailConfirmed
                    };

                    IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                    IdentityResult resultRoleInsertion = await _userManager.AddToRoleAsync(appUser, user.Type);

                    if (result.Succeeded && resultRoleInsertion.Succeeded)
                        return RedirectToAction("Index");
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                }
                return View(user);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
