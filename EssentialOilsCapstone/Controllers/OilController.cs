using EssentialOilsCapstone.Data;
using EssentialOilsCapstone.Models;
using EssentialOilsCapstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EssentialOilsCapstone.Controllers
{
    public class OilController : Controller
    {
        private OilDbContext context;

        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"name", "Name"},
            {"property", "Property"}
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "essentialoils",
            "property"
        };
        public OilController(OilDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index(int id)
        {

            List<OilDetailViewModel> displayOils = new List<OilDetailViewModel>();
            ViewBag.columns = ColumnChoices;

            List<Oil> oils = context.EssentialOils
                .ToList();

            foreach (Oil oil in oils)
            {
                List<OilProperty> oilProperties = context.OilProperty
                    .Where(op => op.OilId == oil.Id)
                    .Include(op => op.Property)
                    .ToList();

                OilDetailViewModel newDisplayOil = new OilDetailViewModel(oil, oilProperties);
                displayOils.Add(newDisplayOil);
            }

            ViewBag.essentialOils = displayOils;

            return View(oils);
        }

        public IActionResult Search(string searchType, string searchTerm)
        {
            List<Oil> oils = new List<Oil>();
            List<OilDetailViewModel> displayOils = new List<OilDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                oils = context.EssentialOils
                    .Include(o => o.Properties)
                    .ToList();

                foreach (var oil in oils)
                {
                    List<OilProperty> oilProperties = context.OilProperty
                        .Where(op => op.OilId == oil.Id)
                        .Include(op => op.Property)
                        .ToList();

                    OilDetailViewModel newDisplayOil = new OilDetailViewModel(oil, oilProperties);
                    displayOils.Add(newDisplayOil);
                }

                ViewBag.title = "All Essential Oils";
            }
            else
            {
                if (searchType == "name")
                {
                    oils = context.EssentialOils
                        .Where(o => o.Name == searchTerm)
                        .ToList();

                    foreach (Oil oil in oils)
                    {
                        List<OilProperty> oilProperties = context.OilProperty
                        .Where(op => op.OilId == oil.Id)
                        .Include(op => op.Property)
                        .ToList();

                        OilDetailViewModel newDisplayOil = new OilDetailViewModel(oil, oilProperties);
                        displayOils.Add(newDisplayOil);
                    }
                }
                else if (searchType == "property")
                {
                    List<OilProperty> oilProperties = context.OilProperty
                        .Where(op => op.Property.Name == searchTerm)
                        .Include(op => op.Oil)
                        .ToList();

                    foreach (var oil in oilProperties)
                    {
                        Oil foundOil = context.EssentialOils
                            .Single(o => o.Id == oil.OilId);

                        List<OilProperty> displayProperties = context.OilProperty
                            .Where(op => op.OilId == foundOil.Id)
                            .Include(op => op.Property)
                            .ToList();

                        OilDetailViewModel newDisplayOil = new OilDetailViewModel(foundOil, displayProperties);
                        displayOils.Add(newDisplayOil);
                    }
                }
                ViewBag.title = "Essential oils with " + ColumnChoices[searchType] + ": " + searchTerm;
            }
            ViewBag.columns = ColumnChoices;
            ViewBag.oils = displayOils;

            return View();
        }
    }
}
