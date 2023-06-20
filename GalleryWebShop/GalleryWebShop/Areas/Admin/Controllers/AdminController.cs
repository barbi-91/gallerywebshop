using Castle.Core.Internal;
using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Areas.Identity.Models;
using GalleryWebShop.Data;
using GalleryWebShop.Models;
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
                        (u, ur) => new { u.Email, u.FirstName, u.LastName, u.UserName, u.Address, u.EmailConfirmed, ur.RoleId, ur.UserId }
                    )
               .Join
                    (
                        _dbContext.Roles,
                        ur => ur.RoleId,
                        r => r.Id,
                        (ur, r) => new User { Email = ur.Email, FirstName = ur.FirstName, LastName = ur.LastName, UserName = ur.UserName, UserType = r.Name, Address = ur.Address, EmailConfirmed = ur.EmailConfirmed, UserId = ur.UserId }
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
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        EmailConfirmed = user.EmailConfirmed
                    };

                    IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                    IdentityResult resultRoleInsertion = await _userManager.AddToRoleAsync(appUser, user.UserType);

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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: AdminController/Edit/5
        public IActionResult Edit(string? id)
        {
            if (id == null || _dbContext.Users == null)
            {
                return NotFound();
            }

            var userById = _dbContext.Users
                .Join
                    (
                        _dbContext.UserRoles,
                        u => u.Id,
                        ur => ur.UserId,
                        (u, ur) => new { u.Email, u.FirstName, u.LastName, u.UserName, u.Address, u.EmailConfirmed, ur.RoleId, ur.UserId }
                    )
               .Join
                    (
                        _dbContext.Roles,
                        ur => ur.RoleId,
                        r => r.Id,
                        (ur, r) => new EditUser { Email = ur.Email, FirstName = ur.FirstName, LastName = ur.LastName, UserName = ur.UserName, /*UserType = r.Name,*/ Address = ur.Address, EmailConfirmed = ur.EmailConfirmed, UserId = ur.UserId }
                    )
                .Where(uIdr => uIdr.UserId == id).FirstOrDefault();

            if (userById == null)
            {
                return NotFound();
            }


            var roleById = _dbContext.Users
                .Join
                    (
                        _dbContext.UserRoles,
                        u => u.Id,
                        ur => ur.UserId,
                        (u, ur) => new { u.Id, ur.RoleId, ur.UserId }
                    )
               .Join
                    (
                        _dbContext.Roles,
                        ur => ur.RoleId,
                        r => r.Id,
                        (ur, r) => new { IdUser = ur.Id, FkUserRoleUser = ur.UserId, FkUserRoleRole = ur.RoleId, NameRole = r.Name, IdRole = r.Id }
                    )
                .Where(u => u.IdUser == id).Select(r => r.IdRole).Single();

            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? "";
            ViewBag.RoleById = roleById;
            return View(userById);
        }


        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Edit(string id, [Bind("UserId,UserName,Email,EmailConfirmed, FirstName,LastName,Address")]
            EditUser user,
            string roleId)
        {
            try
            {
                if (id != user.UserId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var userById = await _userManager.FindByIdAsync(user.UserId);
                    //remove old role
                    var oldRoleNames = await _userManager.GetRolesAsync(userById);
                    var oldRoleName = oldRoleNames.SingleOrDefault();
                    if (oldRoleName != null)
                    {
                        await _userManager.RemoveFromRoleAsync(userById, oldRoleName);
                    }

                    //Update user
                    userById.UserName = user.UserName;
                    userById.Email = user.Email;
                    userById.EmailConfirmed = user.EmailConfirmed;
                    userById.FirstName = user.FirstName;
                    userById.LastName = user.LastName;
                    userById.Address = user.Address;

                    await _userManager.UpdateAsync(userById);

                    
                    //Update role
                    var roleName = _dbContext.Roles.Where(r => r.Id == roleId).Select(r => r.Name).Single();

                    await _userManager.AddToRoleAsync(userById, roleName);

                }
                return RedirectToAction(nameof(Index),"Admin");
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
