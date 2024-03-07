using Microsoft.AspNetCore.Mvc;
using AspNetCore.Reporting;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        public IWebHostEnvironment _webHostEnvironment { get; set; }

        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string mimetype = "";
            int extension = 1;
            //This is somehow not working
            var path = string.Format("{0}\\Reports\\Report1.rdlc", this._webHostEnvironment.WebRootPath);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("Params1", "Parameter from page");
            LocalReport localReport = new(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }
    }
}
