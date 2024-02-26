using Microsoft.Extensions.Configuration;

namespace TaskManagerAPI.Persistence;

static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "../../Presentation/TaskManagerAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("DbConnectionPostgreSql");
        }
    }
}