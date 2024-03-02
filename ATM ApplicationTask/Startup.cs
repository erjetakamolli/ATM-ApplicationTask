using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ATM_ApplicationTask.Models;
using ATM_AplicationTask.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ATM_ApplicationTask
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            // connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ATMDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ATMDbConnection")));
         //   services.AddScoped<CustomerService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATM API V1");
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            //AppDbInitializer.Seed(app);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
   
