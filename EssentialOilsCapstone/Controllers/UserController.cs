using EssentialOilsCapstone.Areas.Identity.Data;
using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private OilDbContext context;
        public UserController(OilDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View("Cabinet");
        }

        [HttpPost("/User/AddToCabinet")]
        public IActionResult AddToCabinet(string userName, Oil oil)
        {
            if (ModelState.IsValid)
            {
                UserOil userOil = new UserOil();
                userOil.Oil = oil;
                userOil.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                context.UserOil.Add(userOil);
                context.SaveChanges();
            }

            return Redirect("/Oil/Search");
        }
    }
}
