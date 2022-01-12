using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EssentialOilsCapstone.Areas.Identity.Data;
using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EssentialOilsCapstone.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<EssentialOilsCapstoneUser> userManager;
        private OilDbContext context;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<EssentialOilsCapstoneUser> userMgr, OilDbContext dbContext)
        {
            roleManager = roleMgr;
            userManager = userMgr;
            context = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.roles = roleManager.Roles;
            ViewBag.users = context.Users.Select(u => u.UserName).ToList();

            return View();
        }

        public IActionResult AddRole()
        {
            AddRoleViewModel addRoleViewModel = new AddRoleViewModel();
            return View(addRoleViewModel);


        }

        [HttpPost]
        public IActionResult AddRole(string name)
        {
            if(ModelState.IsValid)
            {
                roleManager.CreateAsync(new IdentityRole { Name = name });
                context.SaveChangesAsync();
            }

            return Redirect("Index");
        }

        public IActionResult ChangeUserRole()
        {
            List<EssentialOilsCapstoneUser> users = context.Users.ToList();
            List<IdentityRole> roles = roleManager.Roles.ToList();

            ChangeUserRoleViewModel changeUserRoleViewModel = new ChangeUserRoleViewModel(users, roles);

            return View(changeUserRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserRole(ChangeUserRoleViewModel changeUserRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                EssentialOilsCapstoneUser theUser = context.Users.Find(changeUserRoleViewModel.UserId);
                IdentityRole theRole = context.Roles.Find(changeUserRoleViewModel.RoleId);

                await UserManager<EssentialOilsCapstoneUser>.AddToRoleAsync(theUser, theRole.Name);
                context.SaveChangesAsync();

                return Redirect("Index");
            }

            return View(changeUserRoleViewModel);
        }
    }
}
