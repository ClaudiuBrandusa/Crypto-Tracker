using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Utils.HTTP
{
    public class HttpUtil
    {
        public static async Task<bool> PostAsync(object model, string endpoint, string type = "application/json")
        {
            using (var client = new HttpClient())
            {
                if (model == null)
                {
                    using (var response = await client.PostAsync(endpoint, new StringContent("")))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();

                        return response.IsSuccessStatusCode;
                    }
                }

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, type);

                using (var response = await client.PostAsync(endpoint, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    return response.IsSuccessStatusCode;
                }
            }
        }

        public static async Task<bool> PostAuthorizedAsync(object model, string endpoint, string token, string type = "application/json")
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                if (model == null)
                {
                    using (var response = await client.PostAsync(endpoint, new StringContent("")))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();

                        return response.IsSuccessStatusCode;
                    }
                }

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, type);

                using (var response = await client.PostAsync(endpoint, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    return response.IsSuccessStatusCode;
                }
            }
        }

        public static async Task<HttpResponseMessage> PostAsyncWithResults(object model, string endpoint, string type = "application/json")
        {
            using (var client = new HttpClient())
            {
                if (model == null)
                {
                    return await client.PostAsync(endpoint, new StringContent(""));
                }

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, type);

                return await client.PostAsync(endpoint, content);
            }
        }
    }
}
