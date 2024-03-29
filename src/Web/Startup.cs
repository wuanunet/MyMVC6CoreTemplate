﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMVC6CoreTemplate.Core.Interfaces.Services;
using MyMVC6CoreTemplate.Core.Services;
using MyMVC6CoreTemplate.Core.Common;
using MyMVC6CoreTemplate.Core.Repositories;
using MyMVC6CoreTemplate.Core.Interfaces.Repositories;

namespace MyMVC6CoreTemplate.Web
{
    public class Startup
    {
        //public IConfigurationRoot Configuration { get; set; }
        private IServiceCollection _Services;

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            AppHelper.RootPath = env.WebRootPath;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this._Services = services;
            // Add framework services.
            services.AddMvc();

            // Add DbContext
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<MyDbContext>();

            //Dependency Injection
            DependencyInjection();
        }

        private void DependencyInjection()
        {
            //services
            this._Services.AddTransient<IMyInfoService, MyInfoService>();

            //repositories
            this._Services.AddTransient<IMyInfoRepository, MyInfoRepository>();

            //others
            //this._Services.AddScoped<MyDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(AppHelper.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
