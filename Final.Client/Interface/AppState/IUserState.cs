using Final.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Client.Interface.AppState
{
    interface IUserState
    {
        Task Register(UserParam user);
        Task Login(Credentials credens);
        Task Logout();
        Task CheckToken();
        Task RefreshToken();
    }
}
