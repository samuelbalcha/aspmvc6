using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using demo.infrastructure;
using demo.repository;
using demo.models;
using demo.orm;

namespace demo
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IRepository<SuperHero>, SuperHeroRepository<SuperHero>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
       
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
