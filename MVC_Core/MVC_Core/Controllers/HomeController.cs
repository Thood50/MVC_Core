using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int start, int end)
        {
            return RedirectToAction("Result", new { start, end });
        }

        public IActionResult Result(int start, int end)
        {
            PersonOfTheYear person = new PersonOfTheYear();
            List<PersonOfTheYear> peepsBetween = person.GetPoTY(start, end);

            return View(peepsBetween);
        }
    }
}
