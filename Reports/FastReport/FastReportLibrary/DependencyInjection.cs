using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FastReportLibrary
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFastReportLibrary(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddFastReport();
            services.AddTransient<IWebReportGenerator, TestReportGenerator>();
            return services;
        }

        public static WebApplication UseFastReportLibrary(this WebApplication app)
        {
            app.UseFastReport();
            return app;
        }
    }
}
