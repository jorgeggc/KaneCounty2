using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using DataLibary;
using static DataLibary.BusinessLogic.EmployeeProcessor;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeModel()
        {
            return View();
        }
        public IActionResult viewEmployees(EmployeeModel model)
        {
            var data = LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach(var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    IdentifictionCardID = row.IdentifictionCardID,
                    Name = row.Name,
                    CourtAccessRequired = row.CourtAccessRequired,
                    IDCardNumber = row.IDCardNumber

                });
            }
            return View(employees);
        }        
        public IActionResult EmployeeLog(EmployeeLog model)
        {
            if (ModelState.IsValid)
            {
               CreateEmployeeLog(model.AccessLocationID, 
                   model.StationID, 
                   model.AccessDate, 
                   model.IDCardNumber, 
                   model.DeclineReason);
               return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult EmployeeLog()
        {
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
