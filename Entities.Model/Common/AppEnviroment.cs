using Microsoft.Extensions.Configuration;

namespace Entities.Model.Common
{
    public class AppEnviroment
    {
        public static string DBConnection { get; set; }
        public static string DatabaseName { get; set; }

        public static void SetEnviroment(IConfiguration Configuration)
        {
            DBConnection = Configuration["DBConnection"];
            DatabaseName = Configuration["DatabaseName"];
        }
    }
}
