using System.Net.Http;
using System.Threading.Tasks;

namespace Final.Client.Interface
{
    public interface IRestServices
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> GetAsyncSetAuth(string url);
        HttpResponseMessage PostSync(object param, string url);
        Task<HttpResponseMessage> PostAsync(object param, string url);
        Task<HttpResponseMessage> PostSetAuth(object param, string url);
    }
}
