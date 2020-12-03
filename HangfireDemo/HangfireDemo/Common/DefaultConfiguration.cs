using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Common
{
    public class DefaultConfiguration
    {
        public static IConfiguration Default { get; set; }
        static DefaultConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json");

            Default = builder.Build();
        }
    }
}
