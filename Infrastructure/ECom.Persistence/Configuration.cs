using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECom.API")); //diğer katmana erişim
            configurationManager.AddJsonFile("appsettings.json");// diğer katmandaki json dosyası
            return configurationManager.GetConnectionString("Mssql");
        }
    }
}
