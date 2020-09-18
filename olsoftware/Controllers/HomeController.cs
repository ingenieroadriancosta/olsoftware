using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using olsoftware.Models;
using olsoftware.Models.AllModelsParams;
using olsoftware.Models.DatosS;

namespace olsoftware.Controllers
{
    public class HomeController : Controller
    {
        OlSoftwareDbContext db;
        public HomeController( Models.OlSoftwareDbContext context ){ db = context; }

        public IActionResult Index()
        {
            if( !(new DatosSemilla()).crear( db ) ){
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
