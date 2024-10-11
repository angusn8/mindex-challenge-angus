using System;

using CodeChallenge.Data;
using CodeChallenge.Repositories;
using CodeChallenge.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeChallenge.Config
{
    public class App
    {
        public WebApplication Configure(string[] args)
        {
            args ??= Array.Empty<string>();

            var builder = WebApplication.CreateBuilder(args);

            builder.UseEmployeeDB();
            
            AddServices(builder.Services);

            var app = builder.Build();

            var env = builder.Environment;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedEmployeeDB(app.Services);
            }

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        public void AddServices(IServiceCollection services)
        {
            // Adding Contexts for each database
            services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseInMemoryDatabase("EmployeeDB");
            });

            services.AddDbContext<CompensationContext>(options =>
            {
                options.UseInMemoryDatabase("CompensationDB");
            });

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRespository>(); // Note the typo in 'Respository'
            services.AddScoped<IReportingStructureService, ReportingStructureService>();
            services.AddScoped<ICompensationService, CompensationService>();
            services.AddScoped<ICompensationRepository, CompensationRepository>();

            services.AddControllers();
        }

        private void SeedEmployeeDB(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
                DatabaseSeeder.SeedDatabase(context).Wait();
            }
        }
    }
}
