using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public static class Configuration
    {
        private static readonly IConfigurationRoot ConfigurationRoot;

        static Configuration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            ConfigurationRoot = configurationBuilder.Build();
        }

        public static string MyWebSiteFileConnectionString
        {
            get
            {
                return ConfigurationRoot.GetConnectionString("MyWebSiteFile");
            }
        }

        public static string MyWebSiteAuthConnectionString
        {
            get
            {
                return ConfigurationRoot.GetConnectionString("MyWebSiteAuth");
            }
        }

        public static string MyWebSiteDataConnectionString
        {
            get
            {
                return ConfigurationRoot.GetConnectionString("MyWebSiteData");
            }
        }
    }
}
