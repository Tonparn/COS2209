using Blazored.LocalStorage;
using Final.Client.Interface;
using Final.Shared;
using System.Threading.Tasks;

namespace Final.Client.Service
{
    public class AuthServices : IAuthServices
    {
        private readonly ILocalStorageService _localStorage;

        public AuthServices(ILocalStorageService localSotrage)
        {
            _localStorage = localSotrage;
        }

        public async Task<JwtToken> GetJwt(string name)
        {
            return new JwtToken
            {
                Name = name,
                AccessToken = await GetAccessTokenAsync(),
                RefreshToken = await GetRefreshTokenAsync()
            };
        }

        //Access Token Implementation
        public async Task SetAccessTokenAsync(string accessToken)
            => await _localStorage.SetItem("authToken", accessToken);

        public Task<string> GetAccessTokenAsync()
            => _localStorage.GetItem<string>("authToken");

        public async Task RemoveAccessTokenAsync()
            => await _localStorage.RemoveItem("authToken");

        //Refresh Token Implementation
        public async Task SetRefreshTokenAsync(string refreshToken)
            => await _localStorage.SetItem("refreshToken", refreshToken);

        public async Task<string> GetRefreshTokenAsync()
            => await _localStorage.GetItem<string>("refreshToken");

        public async Task RemoveRefreshTokenAsync()
            => await _localStorage.RemoveItem("refreshToken");
    }
}
