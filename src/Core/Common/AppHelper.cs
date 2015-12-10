using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace MyMVC6CoreTemplate.Core.Common
{
    public class AppHelper
    {
        public static string RootPath { get; set; }

        public static IConfigurationRoot Configuration { get; set; } = 
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }
}
