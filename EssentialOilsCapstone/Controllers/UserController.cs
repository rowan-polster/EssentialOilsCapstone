using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Controllers
{
    public class UserController : Controller
    {
        private OilDbContext context;
        public UserController(OilDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View("Cabinet");
        }

        [HttpPost]
        public IActionResult AddToCabinet(string userName, Oil oil)
        {
            if (ModelState.IsValid)
            {
                UserOil userOil = new UserOil();
                userOil.Oil = oil;
                userOil.User = context.Users.Find(userName);

                context.UserOil.Add(userOil);
                context.SaveChanges();
            }

            return View("/Oil/Search");
        }
    }
}
