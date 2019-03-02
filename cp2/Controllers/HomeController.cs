using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cp2.Models;
using cp2.DataAccess;
using cp2.Data;

namespace cp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly InstructionRepository instructionRepository;

        public HomeController(ApplicationDbContext context)
        {
            instructionRepository = new InstructionRepository(context);
        }

        public IActionResult Index()
        {
            var instructions = instructionRepository.GetInstructions();

            return View("List", instructions);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
