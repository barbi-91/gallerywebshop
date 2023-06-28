using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Areas.Identity.Models;
using GalleryWebShop.Common;
using GalleryWebShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public ActionResult Index(string? searchQuery)
        {
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;
                ViewBag.Search = searchQuery;

                var userRoles = _dbContext.Users
                .Join
                    (
                        _dbContext.UserRoles,
                        u => u.Id,
                        ur => ur.UserId,
                        (u, ur) => new { u.Email, u.FirstName, u.LastName, u.Address, u.EmailConfirmed, ur.RoleId, ur.UserId, u.Image }
                    )
               .Join
                    (
                        _dbContext.Roles,
                        ur => ur.RoleId,
                        r => r.Id,
                        (ur, r) => new User { Email = ur.Email, FirstName = ur.FirstName, LastName = ur.LastName, UserType = r.Name, Address = ur.Address, EmailConfirmed = ur.EmailConfirmed, UserId = ur.UserId, Image = ur.Image }
                    );
                List<string> rolesList = new List<string>();
                foreach (User user in userRoles)
                {
                    var roleName = user.UserType;
                    var roleId = _roleManager.Roles.Where(r => r.Name == roleName).Select(r => r.Id).Single();

                    if (roleName.Contains("Admin"))
                    {
                        rolesList.Add(user.UserId);
                    }
                };
                ViewBag.Admins = rolesList;


                if (!String.IsNullOrWhiteSpace(searchQuery))
                {
                    userRoles = userRoles.Where(ur => ur.FirstName.ToLower().Contains(searchQuery.ToLower()));
                }

                return View(userRoles);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<User>());
            }
        }

        // GET: AdminController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            try
            {
                //Todo: check if user exists

                var user = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();

                var roleNameByIds = await _userManager.GetRolesAsync(user);
                var roleName = roleNameByIds.SingleOrDefault();

                var userModel = new User
                {
                    UserType = roleName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.Id,
                    Address = user.Address,
                    EmailConfirmed = user.EmailConfirmed,
                    Image = user.Image
                };
                return View(userModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Admin");
            }
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;
                ViewBag.Roles = _roleManager.Roles.ToList();
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Admin");
            }
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IFormFile? Image)
        {
            try
            {
                ViewBag.Roles = _roleManager.Roles.ToList();

                if (ModelState.IsValid)
                {
                    if (Image != null)
                    {
                        // Store image file in folder using path
                        var getFimeExtension = Path.GetExtension(Image.FileName);
                        var imageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" +
                               Image.FileName.ToLower().Replace(" ", "_");

                        var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/users",
                            imageName
                            );
                        //Creating Directory using path
                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            Image.CopyTo(stream);
                        }
                        // Store only the file name in the table column
                        user.Image = imageName;
                    }
                    Helper.TrimStringProperties(user);
                    ApplicationUser appUser = new ApplicationUser()
                    {
                        UserName = user.Email,
                        NormalizedUserName = user.Email.ToUpper(),
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        EmailConfirmed = user.EmailConfirmed,
                        Image = user.Image
                    };

                    IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                    IdentityResult resultRoleInsertion = await _userManager.AddToRoleAsync(appUser, user.UserType);

                    if (result.Succeeded && resultRoleInsertion.Succeeded)
                        return RedirectToAction("Index", "Admin");
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
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;

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
                            (u, ur) => new { u.Email, u.FirstName, u.LastName, u.Address, u.EmailConfirmed, ur.RoleId, ur.UserId, u.Image }
                        )
                   .Join
                        (
                            _dbContext.Roles,
                            ur => ur.RoleId,
                            r => r.Id,
                            (ur, r) => new EditUser { Email = ur.Email, FirstName = ur.FirstName, LastName = ur.LastName, Address = ur.Address, EmailConfirmed = ur.EmailConfirmed, UserId = ur.UserId, Image = ur.Image }
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

                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;
                ViewBag.RoleById = roleById;
                return View(userById);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Admin");
            }
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("UserId,Email,EmailConfirmed,FirstName,LastName,Address,Image")]
            EditUser user,
            IFormFile? newImage,
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
                    //dohvacanje ime stare slike
                    var oldImageName = _dbContext.Users.Where(u => u.Id == id).Select(u => u.Image).Single();
                    Helper.TrimStringProperties(user);

                    if (newImage != null)
                    {
                        var newImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" +
                            newImage.FileName.ToLower().Replace(" ", "_");
                        var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/users",
                            newImageName
                            );

                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }
                        user.Image = newImageName;

                    }

                    var userById = await _userManager.FindByIdAsync(user.UserId);
                    //remove old role
                    var oldRoleNames = await _userManager.GetRolesAsync(userById);
                    var oldRoleName = oldRoleNames.SingleOrDefault();
                    if (oldRoleName != null)
                    {
                        await _userManager.RemoveFromRoleAsync(userById, oldRoleName);
                    }

                    //Update user
                    userById.Email = user.Email;
                    userById.EmailConfirmed = user.EmailConfirmed;
                    userById.FirstName = user.FirstName;
                    userById.LastName = user.LastName;
                    userById.Address = user.Address;
                    userById.Image = user.Image;

                    await _userManager.UpdateAsync(userById);


                    //Update role
                    var roleName = _dbContext.Roles.Where(r => r.Id == roleId).Select(r => r.Name).Single();

                    await _userManager.AddToRoleAsync(userById, roleName);

                    //Delete old image from folder
                    if (!string.IsNullOrEmpty(oldImageName))
                    {
                        //dohvacanje putanje stare slike
                        var getImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/users",
                            oldImageName
                            );
                        //brisanje direktorija
                        if (System.IO.File.Exists(getImagePath))
                        {
                            System.IO.File.Delete(getImagePath);
                        }
                    }

                }
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: AdminController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;
                var user = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();

                var roleNameByIds = await _userManager.GetRolesAsync(user);
                var roleName = roleNameByIds.SingleOrDefault();

                var userModel = new User
                {
                    UserType = roleName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.Id,
                    Address = user.Address,
                    EmailConfirmed = user.EmailConfirmed
                };
                return View(userModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Admin");
            }
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, User user)
        {
            try
            {
                if (id != user.UserId)
                {
                    return NotFound();
                }

                var findUser = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();
                var rolesForUser = await _userManager.GetRolesAsync(findUser);
                var roleForUser = rolesForUser.SingleOrDefault();
                var role = _dbContext.Roles.Where(r => r.Name == roleForUser).Select(r => r.Id);

                if (findUser != null && roleForUser != null)
                {
                    await _userManager.RemoveFromRoleAsync(findUser, roleForUser);
                    await _userManager.DeleteAsync(findUser);

                    if (!String.IsNullOrWhiteSpace(findUser.Image))
                    {
                        var deleteImageFromPath = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot/images/users",
                           findUser.Image
                       );
                        if (System.IO.File.Exists(deleteImageFromPath))
                        {
                            System.IO.File.Delete(deleteImageFromPath);
                        }
                    }
                }
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Delete));
            }
        }
    }
}
