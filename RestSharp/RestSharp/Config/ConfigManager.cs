using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTrain.Config
{
    internal class ConfigManager
    {
        public enum KEYS {
            sec_id,
            sec_userId,
            third_id,
            forth_userId,
            fifth_id,
            baseUrl,
            emptyBody
        }

        public static int getIntProperty(KEYS key) {
            var text = File.ReadAllText(@"Config\TestData.json");
            var json = JObject.Parse(text);

            return json["testData"]
                .Select(token => token[key.ToString()].Value<int>()).ToList()[0];
        }

        public static string getStringProperty(KEYS key)
        {
            var text = File.ReadAllText(@"Config\TestData.json");
            var json = JObject.Parse(text);

            return json["testData"]
                .Select(token => token[key.ToString()].Value<string>()).ToList()[0];
        }
    }
}
