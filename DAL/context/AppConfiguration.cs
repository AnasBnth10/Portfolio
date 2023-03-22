using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.context
{
    public class AppConfiguration
    {
        public string sqlConnectionString { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path,false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSetting.Value;
        }
        
    }
}
