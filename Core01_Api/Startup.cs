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
using Core01_Api.Infrastarcture;

namespace Core01_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            ////
            //var builder = new ConfigurationBuilder()
            //      .SetBasePath(env.ContentRootPath)
            //         .AddJsonFile("appsettings.json", optional: true, true)
            //           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            //builder.AddEnvironmentVariables();
            //Configuration = builder.Build();
            ////

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //
            services.AddSingleton<IRepository, TodoRepository>();
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); // Add this middleware to pipeline request

            app.UseRouting(); // Add this middleware to pipeline request

            app.UseAuthorization(); // Add this middleware to pipeline request

            app.UseEndpoints(endpoints => // Add this middleware to pipeline request
            {
                endpoints.MapControllers();
            });
        }
    }
}
