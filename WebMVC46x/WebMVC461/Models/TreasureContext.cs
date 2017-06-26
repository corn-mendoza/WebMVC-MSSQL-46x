using Pivotal.Workshop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVC461.Models
{
    public class TreasureContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TreasureContext() : base("name=TreasureContext")
        {
        }

        public static string ConnectionString
        {
            get
            {
                CFEnvironmentVariables _env = new CFEnvironmentVariables(ServerConfig.Configuration);
                var _connect = _env.getConnectionStringForDbService("user-provided", "treasuresdb");
                if (_connect != null)
                {
                    Console.WriteLine($"Using connection string '{_connect}' for catalog");
                    return _connect;
                }

                Console.WriteLine($"Using default connection string for cataglog");

                return "TreasureContext";
            }
        }

        public System.Data.Entity.DbSet<Workshop.Models.Treasure> Treasures { get; set; }
    }
}
