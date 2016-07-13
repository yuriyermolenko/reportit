using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReportIT.Application.Services;
using ReportIT.Infrastructure.Adapter;
using ReportIT.Infrastructure.Base.Adapter;

namespace ReportIT
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvcCore()
                .AddJsonFormatters();

            // application services
            services.AddTransient<ICityService, CityService>();

            // factories
            var typeAdapterFactory = new AutomapperTypeAdapterFactory();

            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
