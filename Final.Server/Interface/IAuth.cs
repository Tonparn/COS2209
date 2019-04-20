using Final.Shared;
using System.Threading.Tasks;

namespace Final.Server.Interface
{
    public interface IAuth
    {
        string BuildAccessToken(string email, string name);
        string BuildRefreshToken();
        Task<JwtToken> RefreshToken(JwtToken token);
        Task SaveToken(string email, string refreshToken);
    }
}