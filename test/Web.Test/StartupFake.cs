using LightMock;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyMVC6CoreTemplate.Core.Common;
using MyMVC6CoreTemplate.Core.Interfaces.Repositories;
using MyMVC6CoreTemplate.Core.Interfaces.Services;
using MyMVC6CoreTemplate.Core.Repositories;
using MyMVC6CoreTemplate.Core.Services;
using MyMVC6CoreTemplate.Core.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6CoreTemplate.Web.Test
{
    public class StartupFake
    {
        //public IConfigurationRoot Configuration { get; set; }
        private IServiceCollection _Services;

        public StartupFake(IHostingEnvironment env)
        {
            AppHelper.RootPath = env.WebRootPath;
            // Set up configuration sources.
            //AppHelper.InitAppConfiguration();
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
            this._Services.AddTransient<IMyInfoRepository, MyInfoRepositoryMock>();

            //others

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<StartupFake>(args);
    }
}
