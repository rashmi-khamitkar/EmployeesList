using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeesList.Models;
using EmployeesList.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace EmployeesList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        HelperAPI _api = new HelperAPI();

        public async Task<IActionResult> Index(string searchString,string searchDepartment)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["DepartmentFilter"] = searchDepartment;
            List<Employee> employeesList = new List<Employee>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/employeedepartment");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employeesList = JsonConvert.DeserializeObject<List<Employee>>(result);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                employeesList = employeesList.Where(emp => emp.FirstName.ToLower().Contains(searchString.ToLower().Trim())
                    || emp.LastName.ToLower().Contains(searchString.ToLower().Trim())).ToList();
            }

            if(!String.IsNullOrEmpty(searchDepartment))
            {
                employeesList = employeesList.Where(dept => dept.DepartmentName.ToLower().Contains(searchDepartment.ToLower().Trim())
                    || dept.SubDepartmentName.ToLower().Contains(searchDepartment.ToLower().Trim())).ToList();
            }

                return View(employeesList);
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
