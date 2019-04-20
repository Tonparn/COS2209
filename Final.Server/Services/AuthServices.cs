using Final.Server.Common;
using Final.Server.DbContext;
using Final.Server.Interface;
using Final.Server.Model;
using Final.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Final.Server.Services
{
    public class AuthServices : IAuth
    {
        private readonly IConfiguration _config;
        private readonly UserContext _userContext;

        public AuthServices(IConfiguration config, IOptions<Settings> settings)
        {
            _userContext = new UserContext(settings);
            _config = config;
        }

        public string BuildAccessToken(string email, string name)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, name),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return GenerateToken(claims);
        }

        public string BuildRefreshToken()
        {
            byte[] randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task SaveToken(string name, string refreshToken)
        {
            await _userContext.User.UpdateOneAsync(FindUser.Name(name), UpdateUser.CreateRefreshToken(refreshToken));
        }

        public async Task<JwtToken> RefreshToken(JwtToken token)
        {   
            ClaimsPrincipal principal = PrincipalToken(token.AccessToken);

            User userCheck = await _userContext.User.Find(FindUser.Name(principal.Identity.Name)).SingleAsync();

            if(userCheck == null || userCheck.RefreshToken != token.RefreshToken)
            {
                throw new RefreshTokenException(Message.RefreshTokenNotFound);
            }

            string newRefreshToken = BuildRefreshToken();

            await SaveToken(principal.Identity.Name, newRefreshToken);

            return new JwtToken
            {
                Name = principal.Identity.Name,
                AccessToken = GenerateToken(principal.Claims),
                RefreshToken = newRefreshToken
            };
        }

        //Not Interface

        private ClaimsPrincipal PrincipalToken(string token)
        {
            var tokenValid = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValid, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            bool isValid = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

            if (jwtSecurityToken == null || !isValid)
            {
                throw new SecurityTokenException();
            }

            return principal;
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                 _config["Jwt:Issuer"],
                 _config["Jwt:Audience"],
                 claims,
                 expires: DateTime.Now.AddHours(double.Parse(_config["jwt:AccessExpireTime"])),
                 signingCredentials: sign
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
