using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using quotingdojo3.Models;
using MySQL.Data.EntityFrameworkCore.Extensions;


namespace quotingdojo3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSession();
            string Server = 
            string Port = 
            string Database = 
            string UserId = 
            string Password = 
            string Connection = $"Server={Server};port={Port};database={Database};uid={UserId};pwd={Password};";
            services.AddDbContext<Quotingdojo3Context>(options => options.UseMySQL(Connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}
