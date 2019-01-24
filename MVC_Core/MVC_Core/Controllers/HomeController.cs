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
        /// <summary>
        /// Intial Action that loads the Index.cshtml page
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Grabs the inputed fields from the form and post the data/redirects the data to another action
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Calls and sends data to another action</returns>
        [HttpPost]
        public IActionResult Index(int start, int end)
        {
            return RedirectToAction("Result", new { start, end });
        }

        /// <summary>
        /// recieves data from form on index and runs it through the logic in our PoTY class and returns a list of people
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Returns a view to results sending a list of peeps with it</returns>
        public IActionResult Result(int start, int end)
        {
            PersonOfTheYear person = new PersonOfTheYear();
            List<PersonOfTheYear> peepsBetween = person.GetPoTY(start, end);

            return View(peepsBetween);
        }
    }
}
