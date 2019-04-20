using Blazored.LocalStorage;
using Final.Client.Interface;
using Final.Shared;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Final.Client
{
    public class UserState
    {
        private readonly IRestServices _restServices;

        private readonly IAuthServices _authServices;

        public bool IsLoggedIn { get; private set; } = false;
        public bool IsRegister { get; private set; } = false;
        public string Status { get; private set; }
        public string Name { get; private set; }

        public UserState(IRestServices restServices, IAuthServices authServices)
        {
            _restServices = restServices;
            _authServices = authServices;
        }

        public async Task Register(UserParam user)
        {
            var response = await _restServices.PostAsync(user, Urls.Endpoint.User.Register);

            if (response.IsSuccessStatusCode)
            {
                IsRegister = true;
            }
            else
            {
                Status = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task Login(Credentials credens)
        {
            var response = await _restServices.PostAsync(credens, Urls.Endpoint.User.Login);

            if (response.IsSuccessStatusCode)
            {
                IsLoggedIn = true;

                JwtToken jwt = JsonConvert.DeserializeObject<JwtToken>(await response.Content.ReadAsStringAsync());

                await _authServices.SetAccessTokenAsync(jwt.AccessToken);
                await _authServices.SetRefreshTokenAsync(jwt.RefreshToken);
            }
            else
            {
                Status = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task Logout()
        {   
            var response = await _restServices.PostAsync(await _authServices.GetJwt("Admin"), Urls.Endpoint.User.Logout);

            if (response.IsSuccessStatusCode)
            {
                IsLoggedIn = false;

                await _authServices.RemoveAccessTokenAsync();
                await _authServices.RemoveRefreshTokenAsync();
            }
        }

        public async Task CheckToken()
        {
            var token = await _authServices.GetAccessTokenAsync();

            if (token != null)
            {
                IsLoggedIn = true;
            }
        }

        public async Task RefreshToken(Func<Task> callback)
        {
            var response =  await _restServices.PostAsync(await _authServices.GetJwt("Admin"), Urls.Endpoint.Auth.RefreshToken);

            if(response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                JwtToken newJwt = JsonConvert.DeserializeObject<JwtToken>(responseContent);

                await _authServices.SetAccessTokenAsync(newJwt.AccessToken);
                await _authServices.SetRefreshTokenAsync(newJwt.RefreshToken);

                await callback();
            }
        }
    }
}