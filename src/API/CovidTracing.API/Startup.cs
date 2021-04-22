using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CovidTracing.API.Data;
using CovidTracing.API.Repository.Interface;
using CovidTracing.API.Repository;
using Microsoft.OpenApi.Models;

namespace CovidTracing.API
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
            services.AddControllers();

            services.AddDbContext<CovidTracingAPIDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CovidTracingAPIDBContext")), ServiceLifetime.Singleton);

            services.AddSingleton<IPHIRepository,PHIRepository>();
            services.AddSingleton<ICDCRepository,CDCRepository>();
            services.AddSingleton<ICitizensRepository,CitizensRepository>();
            services.AddSingleton<ITravelLogRepository, TravelLogRepository>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CovidTracingAPI", Version = "v1" });
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CovidTracingAPI v1"); });
        }
    }
}
