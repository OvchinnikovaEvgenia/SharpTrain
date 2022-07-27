using SpecFlowProjectCars.PageObject.Models;
using System.Text.Json;

namespace SpecFlowProjectCars.PageObject.Utils
{
    internal class JsonUtils
    {
        public static SearchCarForSaleModel DeserializeJson(String pathToFile) 
        {
            string jsonString = File.ReadAllText(pathToFile);
            return JsonSerializer.Deserialize<SearchCarForSaleModel>(jsonString);
        }
    }
}
