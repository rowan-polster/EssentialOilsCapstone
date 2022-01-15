using EssentialOilsCapstone.Areas.Identity.Data;
using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.Models;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<OilDetailViewModel> displayOils = new List<OilDetailViewModel>();

            List<UserOil> userOilEntries = context.UserOil
                        .Where(uo => uo.UserId == currentUserId)
                        .Include(uo => uo.Oil)
                        .ToList();

            foreach (var oil in userOilEntries)
            {
                Oil foundOil = context.EssentialOils
                    .Single(o => o.Id == oil.OilId);
                
                string userNotes = context.UserOil.Find(foundOil.Id, currentUserId).Notes;

                List<OilProperty> displayProperties = context.OilProperty
                    .Where(op => op.OilId == foundOil.Id)
                    .Include(op => op.Property)
                    .ToList();

                OilDetailViewModel newDisplayOil = new OilDetailViewModel(foundOil, userNotes, displayProperties);
                displayOils.Add(newDisplayOil);
            }
            ViewBag.userOils = displayOils;
            return View();
        }


        [HttpPost("/User/Index")]
        public IActionResult AddToCabinet(int oilId)
        {
            if (ModelState.IsValid)
            {
                UserOil userOil = new UserOil();
                userOil.OilId = oilId;
                userOil.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                context.UserOil.Add(userOil);
                context.SaveChanges();
            }

            return Redirect("/Oil/Search");
        }

        [HttpPost]
        public IActionResult Delete(int oilId)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            UserOil theUserOil = context.UserOil.Find(oilId, currentUserId);
            context.UserOil.Remove(theUserOil);

            context.SaveChanges();

            return Redirect("/User/Index");
        }

        [HttpPost]
        public IActionResult SaveNotes(int oilId, string notes)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                context.UserOil.Find(oilId, currentUserId).Notes = notes;
            }
            context.SaveChanges();
            return Redirect("/User/Index");
        }

        [HttpPost]
        public IActionResult SaveNumStars(int oilId, int numStars)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                context.UserOil.Find(oilId, currentUserId).NumStars = numStars;
            }
            context.SaveChanges();
            return Redirect("/User/Index");
        }
    }
}
