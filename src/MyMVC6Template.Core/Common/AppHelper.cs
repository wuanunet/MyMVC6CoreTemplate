using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6Template.Core.Common
{
    public class AppHelper
    {
        public static IConfigurationRoot Configuration { get; set; }
    }
}
