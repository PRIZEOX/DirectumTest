using Directum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Directum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User model)
        {
            StreamWriter sw = new StreamWriter("D:\\visual\\Directum\\Directum\\user.json");
            var user = new User()
            {
                name = model.name,
                lastname = model.lastname,
                patronyc = model.patronyc,
                birthDate = model.birthDate,
            };
            string a = "{";
            string b = "}";
            string text = $"\"name\":\"{user.name}\"\n" + $"\"lastname\":\"{user.lastname}\"\n" + $"\"patronyc\":\"{user.patronyc}\"\n" + $"\"birthDate\":\"{user.birthDate}\"";
            string json = a + "\n" + text + "\n" + b;
            Console.WriteLine(json);
            sw.Write(json);
            sw.Close();
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