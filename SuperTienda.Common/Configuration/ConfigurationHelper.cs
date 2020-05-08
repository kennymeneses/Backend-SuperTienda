using Microsoft.Extensions.Configuration;
using System;
namespace SuperTienda.Common.Configuration
{
    public class ConfigurationHelper
    {
        #region GetConfiguration()

        public static IConfigurationRoot GetConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!String.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            return builder.Build();
        }
        #endregion
    }
}
