using Final.Shared;
using System.Threading.Tasks;

namespace Final.Server.Interface
{
    public interface IUser
    {
        Task Register(UserParam user);
        Task<JwtToken> Login(Credentials user);
        Task Logout(string name);
    }
}