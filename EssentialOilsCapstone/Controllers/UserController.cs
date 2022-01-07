using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialOilsCapstone.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View("Cabinet");
        }

        public IActionResult AddToCabinet()
        {

            return View("/Oil/Search");
        }
    }
}
