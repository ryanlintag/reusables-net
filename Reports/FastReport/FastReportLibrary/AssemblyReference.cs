using System.Reflection;

namespace FastReportLibrary
{
    public class AssemblyReference
    {
        public static readonly string ExecuteLocation = Assembly.GetExecutingAssembly().Location.Replace("FastReportLibrary.dll", "");
    }
}
