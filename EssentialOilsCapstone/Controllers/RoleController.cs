using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EssentialOilsCapstone.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private OilDbContext context;

        public RoleController(RoleManager<IdentityRole> roleMgr, OilDbContext dbContext)
        {
            roleManager = roleMgr;
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

            return View("Index");
        }

        public IActionResult ChangeUserRole(string userName, string role)
        {


            return View("Confirmation");
        }
    }
}
