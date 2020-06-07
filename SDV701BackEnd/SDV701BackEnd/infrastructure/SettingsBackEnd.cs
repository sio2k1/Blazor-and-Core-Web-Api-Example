using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SDV701BackEnd.infrastructure
{

    public static class SettingsManager
    {
        public static IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", true, true)
          .Build();
    }
    public class ConnectionSettings
    {

        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
        public DbProviderFactory DBProvider;

        /// <summary>
        /// We have to call it upon settings load, it will creat provider.
        /// </summary>
        public void InitProvider()
        {
            DBProvider = DbProviderFactories.GetFactory(ProviderName);
        }
    }

   

    public class SettingsBackEnd
    {
        public static ConnectionSettings CS = new ConnectionSettings();
 
    }
}
