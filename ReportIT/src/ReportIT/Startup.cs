using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReportIT.Application.Mappings;
using ReportIT.Application.Services;
using ReportIT.DataAccess;
using ReportIT.DataAccess.UnitOfWork;
using ReportIT.DataAccess.UnitOfWork.Base;
using ReportIT.Infrastructure.Adapter;
using ReportIT.Infrastructure.Base.Adapter;
using System.IO;

namespace ReportIT
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Add framework services.
            services
                .AddMvcCore()
                .AddJsonFormatters();

            // application services
            services.AddTransient<ICityService, CityService>();

            services.AddTransient<IDbContext, ReportITDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // factories
            var typeAdapterFactory = new AutomapperTypeAdapterFactory();

            typeAdapterFactory.Register(new AutomapperProfile());

            TypeAdapterFactory.SetCurrent(typeAdapterFactory);

            // Use a PostgreSQL database
            var sqlConnectionString = config["ConnectionStrings:DefaultConnection"];

            services.AddEntityFrameworkNpgsql();

            services.AddDbContext<ReportITDbContext>(options =>
                options.UseNpgsql(
                sqlConnectionString,
                b => b.MigrationsAssembly("ReportIT")
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
