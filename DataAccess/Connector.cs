using EmployeesModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connector
    {
        private static HttpClient client = new HttpClient();

        private const string baseUri = "http://masglobaltestapi.azurewebsites.net/api/";
        public Connector()
        {
            client.Timeout = TimeSpan.FromSeconds(800);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<JArray> SendRequest(Request request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(request.Method, $"{baseUri}/{request.Query}");
            JArray jResponse;
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
            {
                jResponse = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }

            return jResponse;
        }
    }
}
