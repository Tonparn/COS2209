using Blazored.LocalStorage;
using Final.Client.Interface;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared
{
    public class RestServices : IRestServices
    {
        private readonly HttpClient HttpClient;
        private readonly IAuthServices _authServices;

        public RestServices(HttpClient httpClient, IAuthServices authServices)
        {
            HttpClient = httpClient;
            _authServices = authServices;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await HttpClient.GetAsync(url);
        }
        public async Task<HttpResponseMessage> GetAsyncSetAuth(string url)
        {
            await SetAuth();

            return await HttpClient.GetAsync(url);
        }

        public HttpResponseMessage PostSync(object param, string url)
        {
            using (var payload = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, Urls.ContentType.Json))
            {
                return HttpClient.PostAsync(url, payload).Result;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(object param, string url)
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
                var token = await _authServices.GetAccessTokenAsync();

                if (!string.IsNullOrEmpty(token))
                {
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
        }
    }
}
