using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppPelda.Models;

namespace WebAppPelda.Controllers
{
    public class HomeController : Controller
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Név1",
                Phone = "11111111111",
                Score = 2
            },
            new Customer
            {
                Id = 2,
                Name = "Név2",
                Phone = "00000000000",
                Score = 40
            }
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Vasarlo(int id)
        {
            Customer customer = customers.First(c => c.Id == id);
            return View(customer);
        }

        public IActionResult Sajat()
        {
            return View(customers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}