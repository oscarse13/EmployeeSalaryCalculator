using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;
using EmployeeSalaryCalculator.Core.Services;
using EmployeeSalaryCalculator.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeSalaryCalculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeDBRepository>();
            services.AddScoped<IEmployeeFactory, EmployeeFactory>();
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer($@"Server={Configuration["DBServer"]};Database=EmployeeDB;Integrated Security=True"));

            services.AddCors(o => o.AddPolicy("EmployeesCorsPolicy", builder =>
            {
                builder.WithOrigins(Configuration["AllowedDomains"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("EmployeesCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
