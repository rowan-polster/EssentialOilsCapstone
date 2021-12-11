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

        public OilController(OilDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index(int id)
        {

            List<OilDetailViewModel> displayOils = new List<OilDetailViewModel>();

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
    }
}
