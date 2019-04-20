using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Shared.Login
{
    class ResJwtToken
    {
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
