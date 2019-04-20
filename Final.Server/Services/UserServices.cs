using Final.Server.Common;
using Final.Server.DbContext;
using Final.Server.Interface;
using Final.Server.Model;
using Final.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Final.Server.Services
{
    public class UserServices : IUser 
    {
        private readonly UserContext _userContext;
        private readonly IAuth _authServices;

        public UserServices(IOptions<Settings> settings, IAuth authServices)
        {
            _userContext = new UserContext(settings);
            _authServices = authServices;
        }

        public async Task Register(UserParam user)
        {
            User result = await _userContext.User.Find(FindUser.Name(user.Name)).FirstOrDefaultAsync();

            if (result != null)
            {
                throw new RegisterException(Message.NameAlready);
            }

            try
            {
                await _userContext.User.InsertOneAsync(new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
                });
            }
            catch (MongoWriteException ex)
            {
                throw ex;
            }
        }

        public async Task<JwtToken> Login(Credentials credens)
        {
            var result = await _userContext.User.Find(FindUser.Email(credens.Email)).FirstOrDefaultAsync();

            if (result != null && BCrypt.Net.BCrypt.Verify(credens.Password, result.Password))
            {
                string refreshToken = _authServices.BuildRefreshToken();

                await _authServices.SaveToken(result.Name, refreshToken);

                return new JwtToken
                {
                    Name = result.Name,
                    AccessToken = _authServices.BuildAccessToken(credens.Email, result.Name),
                    RefreshToken = refreshToken
                };
            }

            throw new LoginException(Message.InvalidCredens);
        }

        public async Task Logout(string name)
        {
            await _userContext.User.UpdateOneAsync(FindUser.Name(name), UpdateUser.RemoveRefreshToken());
        }
    }
}