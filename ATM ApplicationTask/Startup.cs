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
            //nnectionString = Configuration.GetConnectionString("ATMDbConnection");
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ATMDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ATMDbConnection")));
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
   
