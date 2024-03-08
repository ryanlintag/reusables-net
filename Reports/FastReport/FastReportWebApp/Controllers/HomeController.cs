using FastReportLibrary;
using FastReportWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FastReportWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebReportGenerator _webReportGenerator;
        public HomeController(ILogger<HomeController> logger, IWebReportGenerator webReportGenerator)
        {
            _logger = logger;
            _webReportGenerator = webReportGenerator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TestReport()
        {
            var report = _webReportGenerator.GenerateReport();
            return View(report);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
