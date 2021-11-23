using EssentialOilCapstone.Data;
using EssentialOilCapstone.Models;
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
    }
}
