﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyCodeCamp.Data;

namespace LearningApiCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        private IConfigurationRoot _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddDbContext<CampContext>(ServiceLifetime.Scoped);
            services.AddScoped<ICampRepository, CampRepository>();
            services.AddTransient<CampDbInitializer>();

            services.AddAutoMapper();

            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            CampDbInitializer seeder)
        {
            loggerFactory.AddConsole(_config.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(config =>
            {
                // config.MapRoute("MainAPIRoute", "api/{controller}/{action}");
            });

            seeder.Seed().Wait();
        }
    }
}
