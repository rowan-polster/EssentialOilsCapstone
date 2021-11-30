using EssentialOilCapstone.Data;
using EssentialOilCapstone.Models;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Controllers
{
    public class OilController : Controller
    {
        private OilDbContext context;

        public OilController(OilDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet("/oils")]
        public IActionResult Index()
        {
            List<Oil> oils = context.EssentialOils
                .ToList();
            return View(oils);
        }

        [HttpGet]
        public IActionResult AddEntry()
        {
            List<Treatment> treatments = context.Treatment.ToList();
            AddOilViewModel addOilViewModel = new AddOilViewModel(treatments);
            return View(addOilViewModel);
        }

        /*[HttpPost]
        public IActionResult Add(AddOilViewModel addOilViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory theCategory = context.Categories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = theCategory
                };

                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);

        }*/
    }
}
