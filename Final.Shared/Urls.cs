using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Shared
{
    public static class Urls
    {
        public class Endpoint
        {
            public class User
            {
                public const string Register = "api/User/registration";
                public const string Login = "api/User/login";
                public const string Logout = "api/User/logout";
            }

            public class Learning
            {
                public const string PrepareJupyter = "api/Learning/prepare-jupyter";
                public const string PrepareLesson = "api/Learning/prepare-lesson";
            }

            public class Auth
            {
                public const string RefreshToken = "api/Auth/refresh-token";
            }
        }

        public class ContentType
        {
            public const string Json = "application/json";
        }
    }
}
