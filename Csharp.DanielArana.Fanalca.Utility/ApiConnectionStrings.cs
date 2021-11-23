using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.DanielArana.Fanalca.Utility
{
    public static class ApiConnectionStrings
    {
        static ApiConnectionStrings()
        {

        }

        public static string ConnectionStrinDB
        {
            get 
            { 
                var builder = new ConfigurationBuilder();

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DB");
                return connectionString;
            }
        }
    }
}
