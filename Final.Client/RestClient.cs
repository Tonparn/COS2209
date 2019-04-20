using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared
{
    public class RestClient
    {
        private readonly HttpClient HttpClient;
        private readonly ILocalStorageService LocalStorage;

        public RestClient(HttpClient httpClient, ILocalStorageService localStorage)
        {
            HttpClient = httpClient;
            LocalStorage = localStorage;
        }

        public HttpResponseMessage PostSync(object param, string url)
        {
            using (var payload = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, Urls.ContentType.Json))
            {
                return HttpClient.PostAsync(url, payload).Result;
            }
        }

        public async Task<HttpResponseMessage> Post(object param, string url)
        { 
            using (var payload = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, Urls.ContentType.Json))
            {
                return await HttpClient.PostAsync(url, payload);
            }
        }

        public async Task<HttpResponseMessage> PostSetAuth(object param, string url)
        {
            await SetAuth();

            using (var payload = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, Urls.ContentType.Json))
            {
                return await HttpClient.PostAsync(url, payload);
            }
        }


        private async Task SetAuth()
        {
            if (!HttpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await LocalStorage.GetItem<string>("authToken");

                if (!string.IsNullOrEmpty(token))
                {
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
        }
    }
}
