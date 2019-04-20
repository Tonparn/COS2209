using Final.Shared;
using System.Threading.Tasks;

namespace Final.Client.Interface
{
    public interface IAuthServices
    {
        Task<JwtToken> GetJwt(string name);

        //Access Token Operation
        Task SetAccessTokenAsync(string accessToken);
        Task<string> GetAccessTokenAsync();
        Task RemoveAccessTokenAsync();

        //Refresh Token Operation
        Task SetRefreshTokenAsync(string refreshToken);
        Task<string> GetRefreshTokenAsync();
        Task RemoveRefreshTokenAsync();
    }
}
