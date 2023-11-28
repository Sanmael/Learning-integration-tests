using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Objects
{
    public class GetData
    {     
        public T CreateInstance<T>()  
        {
                        
            string fileName = $"Data//Dev//{typeof(T).Name}.Data.json";

            string jsonContent = File.ReadAllText(fileName);

            T value = JsonSerializer.Deserialize<T>(jsonContent)!;

            return value;
        }

       
    }
}
