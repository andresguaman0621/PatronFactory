using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatronFactory.Configuration;
using PatronFactory.Models;
using System.Diagnostics;
using Tools;

namespace PatronFactory.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> _config;

        public HomeController(IOptions<MyConfig> config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Ingreso en index");
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Ingreso en privacy"); 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}