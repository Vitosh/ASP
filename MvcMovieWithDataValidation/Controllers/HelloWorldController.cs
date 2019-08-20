using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET: /HelloWorld
        public IActionResult Index()
        {
            return View();
        }

        //GET: /HelloWorld/Welcome/

        public IActionResult Welcome(string name, int number = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["Number"] = number;

            return View();
        }

    }
}