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
    public class AdminController : Controller
    {
        private OilDbContext context;

        public AdminController(OilDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*        [HttpGet]*/
        public IActionResult AddEntry()
        {
            List<Property> properties = context.Property.ToList();
            AddOilViewModel addOilViewModel = new AddOilViewModel(properties);
            return View(addOilViewModel);
        }



        [HttpPost]
        public IActionResult AddEntry(AddOilViewModel addOilViewModel, string[] selectedProperties)
        {
            if (ModelState.IsValid)
            {
                Oil newOil = new Oil
                {
                    Name = addOilViewModel.Name,
                    Description = addOilViewModel.Description,
                };

                for (int i = 0; i < selectedProperties.Length; i++)
                {
                    OilProperty oilProperty = new OilProperty();
                    oilProperty.Oil = newOil;
                    oilProperty.PropertyId = int.Parse(selectedProperties[i]);

                    context.OilProperty.Add(oilProperty);
                }

                context.EssentialOils.Add(newOil);
                context.SaveChanges();

                return RedirectToAction("Index", "Oil");
            }

            return View(addOilViewModel);

        }

        public IActionResult Delete()
        {
            ViewBag.oils = context.EssentialOils.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] oilIds)
        {
            foreach (int oilId in oilIds)
            {
                Oil theOil = context.EssentialOils.Find(oilId);
                context.EssentialOils.Remove(theOil);
            }

            context.SaveChanges();

            return Redirect("/Oil");
        }

        [HttpGet("/Admin/Edit/{oilId?}")]
        public IActionResult Edit(int oilId)
        {
            ViewBag.oil = context.EssentialOils.Find(oilId);
            ViewBag.title = "Edit Oil " + ViewBag.oil.Name + " (id = " + ViewBag.oil.Id + ")";
            return View();
        }

        [HttpPost("/Admin/Edit")]
        public IActionResult SubmitEditOilForm(int oilId, string name, string description)
        {
            ViewBag.oil = context.EssentialOils.Find(oilId);
            ViewBag.oil.Name = name;
            ViewBag.oil.Description = description;

            return Redirect("/Oil/Index");
        }
    }
}
