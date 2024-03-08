using FastReport;
using FastReport.Web;
using System.Reflection.Metadata;

namespace FastReportLibrary
{
    public class TestReportGenerator : IWebReportGenerator
    {
        private readonly string reportFileName = "TestReport.frx";
        public WebReport GenerateReport()
        {
            var webReport = new WebReport();
            var directoryLocation = AssemblyReference.ExecuteLocation;
            var reportFile = Path.Combine(directoryLocation, FastReportConstants.ReportFolder, reportFileName);
            webReport.Report.Load(reportFile);
            var success = webReport.Report.Prepare();
            return webReport;
        }
    }
}
