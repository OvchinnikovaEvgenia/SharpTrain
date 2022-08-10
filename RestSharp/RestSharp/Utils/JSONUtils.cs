using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharpTrain
{
    internal class JSONUtils<T>
    {
        public static T DeserializeJson(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);   
        }

        public static Boolean IsJson(string jsonString)
        {
            try
            {
                JsonSerializer.Deserialize<T>(jsonString);
                return true;
            }
            catch(JsonException ex) { 
                return false;
            }
        }

        public static string JsonToString(string pathToFile) {
            return File.ReadAllText(pathToFile);
        }
    }
}
