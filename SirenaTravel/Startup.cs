using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SirenaTravel.Abstractions;
using SirenaTravel.Controllers;
using SirenaTravel.Models;
using SirenaTravel.Servicies;

namespace SirenaTravel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(AirportDirectoryCreate());
            services.AddSingleton<IDistanceCalculator, DistanceCalculator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private IAirportDirectory AirportDirectoryCreate()
        {
            var airportDirectory = new AirportDirectory();
            airportDirectory.Add(new Airport("SVO", 37.4146, 55.9728));
            airportDirectory.Add(new Airport("OMS", 73.3105, 54.9661));
            return airportDirectory;
        }
    }
}
