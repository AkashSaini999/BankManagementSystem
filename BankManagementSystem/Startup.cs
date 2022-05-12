using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BankManagementSystem.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Interface;
using BankManagementSystem.Services;
using BankManagementSystem.Repository;
using BankManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankManagementSystem", Version = "v1" });
            });
            services.AddControllers();
            
            services.AddJWTTokenServices(Configuration);            
            services.AddTransient<IcustomerRespository, CustomerRepository>();
            services.AddTransient<IAuthentication, AuthenticationService>();
            services.AddTransient<ICustomer, CustomerService>();

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<CustomerService>>();
            var loggerloan = serviceProvider.GetService<ILogger<LoanService>>();
            services.AddSingleton(typeof(ILogger), logger);
            services.AddSingleton(typeof(ILogger), loggerloan);

            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<ILoan, LoanService>();
            services.AddDbContext<BankDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DatabaseManagementService.MigrationInitialisation(app);
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankManagementSyatem V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
