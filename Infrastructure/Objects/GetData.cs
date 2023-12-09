using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Infrastructure.Objects
{
    public class GetData
    {
        public static T CreateInstanceResponse<T>(string cenario)
        {

            string fileName = $"Data//Dev//{cenario}.Data.json";

            if (!File.Exists(fileName))
                throw new Exception("File not found.");

            string jsonContent = File.ReadAllText(fileName);

            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonContent)!;
        }

        public static T CreateInstanceRequest<T>(string cenario)
        {           
            var section = GetConfiguration().GetSection(cenario);

            return section.Get<T>();
        }
        public static List<T> CreateInstancesRequests<T>(string cenario)
        {                      
            return GetConfiguration().GetSection(cenario).Get<List<T>>();
        }
        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .Build();
        }

    }
}
