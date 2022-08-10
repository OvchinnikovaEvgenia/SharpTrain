using static RestSharpTrain.Config.ConfigManager;

namespace RestSharp.API
{
    internal class ApiUtils
    {
        public enum STATUS_CODE {
        OK = 200,
        NOT_FOUND = 404,
        CREATED = 201

        }
        public static RestResponse GetRequest(string requestString) {
            var client = new RestClient(getStringProperty(KEYS.baseUrl));
            var request = new RestRequest(requestString);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request, Method.Get);
        }

        public static RestResponse PostRequest(string requestString)
        {
            var client = new RestClient(getStringProperty(KEYS.baseUrl));
            var request = new RestRequest(requestString);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request, Method.Post);
        }

        public static RestResponse PostRequest(RestRequest request)
        {
            var client = new RestClient(getStringProperty(KEYS.baseUrl));
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request, Method.Post);
        }

        public static Boolean IsBodyEmpty(RestResponse response) {
            return response.Content.Equals(getStringProperty(KEYS.emptyBody));
        }
    }
}
