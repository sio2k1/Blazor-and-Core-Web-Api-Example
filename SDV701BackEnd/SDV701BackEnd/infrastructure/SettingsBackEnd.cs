/*
 * Author: Oleg Sivers
 * Date: 01.06.2020
 * Desc: Settings load and make available to access within the app.
*/
using Microsoft.Extensions.Configuration;
using System.Data.Common;

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
        /// We have to call it upon settings load, it will create a provider.
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
