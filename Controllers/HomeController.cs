using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractikaASP.Infrastructure;

namespace PractikaASP.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;

        public HomeController(UptimeService service) => uptime = service;

        public IActionResult Index(bool throwException = false)
        {
            if (throwException)
                throw new NullReferenceException();
            return View(new Dictionary<string, string> { ["Message"] = "Это действие Index", ["Update"] = $"{uptime.Update()} ms" });
        }
        public ViewResult Error() => View(nameof(Index), new Dictionary<string, string> {["Message"] = "This is the Error action" });
    }
}
