using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.Models;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<OilProperty> oilProperties = context.OilProperty
                     .Where(op => op.OilId == context.EssentialOils.Find(oilId).Id)
                     .Include(op => op.Property)
                     .ToList();

            List<Property> theProperties = new List<Property>();

            foreach(OilProperty op in oilProperties)
            {
                theProperties.Add(op.Property);
            }

            List<Property> properties = context.Property.ToList();

            ViewBag.oil = context.EssentialOils.Find(oilId);
            ViewBag.oilId = oilId;
            ViewBag.title = "Edit Oil " + ViewBag.oil.Name + " (id = " + ViewBag.oil.Id + ")";
            ViewBag.allProperties = properties;
            ViewBag.theProperties = theProperties;

            return View();
        }

        [HttpPost("/Admin/Edit")]
        public IActionResult SubmitEditOilForm(int oilId, string name, string description, string[] newProperties)
        {
            context.EssentialOils.Find(oilId).Name = name;
            context.EssentialOils.Find(oilId).Description = description;

            List<OilProperty> oilProperties = context.OilProperty
                     .Where(op => op.OilId == context.EssentialOils.Find(oilId).Id)
                     .Include(op => op.Property)
                     .ToList();

            List<string> oldPropertyNames = new List<string>();
            List<Property> oldProperties = new List<Property>();

            foreach (OilProperty op in oilProperties)
            {
                oldPropertyNames.Add(op.Property.Name);
            }

            foreach(OilProperty op in oilProperties)
            {
                oldProperties.Add(op.Property);
            }


            for (int i = 0; i < oldProperties.Count; i++)
            {
                if (!newProperties.Contains(oldProperties[i].Name))
                {
                    context.Remove(context.OilProperty.Find(oilId, oldProperties[i].Id));
                }
            }

            for (int i = 0; i < newProperties.Length; i++)
            {
                if (!oldPropertyNames.Contains(newProperties[i]))
                {
                    OilProperty oilProperty = new OilProperty();
                    oilProperty.OilId = oilId;
                    oilProperty.PropertyId = int.Parse(newProperties[i]);

                    context.OilProperty.Add(oilProperty);
                }
                                
            }
            context.SaveChanges();

            return Redirect("/Oil/Index");
        }
    }
}
