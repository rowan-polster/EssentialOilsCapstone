using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.Models;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Controllers
{
    public class PropertyController : Controller
    {
        private OilDbContext context;
        public PropertyController(OilDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Property> properties = context.Property.ToList();

            return View(properties);
        }

        public IActionResult Add()
        {
            AddPropertyViewModel addPropertyViewModel = new AddPropertyViewModel();
            return View(addPropertyViewModel);


        }


        [HttpPost]
        public IActionResult Add(Property property)
        {
            if (ModelState.IsValid)
            {
                context.Property.Add(property);
                context.SaveChanges();
                return RedirectToAction("AddEntry", "Oil");
            }

            return View("Add", property);

        }
    }
}
