using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppPelda.Models;
using WebAppPelda.Services;

namespace WebAppPelda.Controllers
{
    public class HomeController : Controller
    {
        List<Customer> customers = new List<Customer>
        {
            //new Customer
            //{
            //    Id = 1,
            //    Name = "Név1",
            //    Phone = "11111111111",
            //    Score = 2
            //},
            //new Customer
            //{
            //    Id = 2,
            //    Name = "Név2",
            //    Phone = "00000000000",
            //    Score = 40
            //}
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
            Customer valasztottcustomer = new VasarloService().GetById(id);
            return View(valasztottcustomer);
        }

        public IActionResult Sajat()
        {
            List<Customer> customers = new VasarloService().GetAllCustomer();
            return View(customers);
        }
        public IActionResult VasarloAdatai(int id)
        {
            Customer valasztottcustomer = new VasarloService().GetAllCustomer().FirstOrDefault(y => y.Id == id);
            return View(valasztottcustomer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateVasarlo()
        {
            Customer uresVasarlo = new Customer();
            return View(uresVasarlo);
        }
        [HttpPost]
        public IActionResult CreateVasarlo(Customer customer)
        {
            string result = new VasarloService().PostCustomer(customer);
            TempData["Success message"] = result;
            return RedirectToAction(nameof(CreateVasarlo));
        }

        public IActionResult PutVasarlo()
        {
            Customer uresVasarlo2 = new Customer();
            return View(uresVasarlo2);
        }
        [HttpPost]
        public IActionResult PutVasarlo(Customer customer)
        {
            string result = new VasarloService().PutCustomer(customer);
            TempData["Success message"] = result;
            return RedirectToAction(nameof(PutVasarlo));
        }

    }
}