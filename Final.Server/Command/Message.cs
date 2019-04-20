using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Server.Common
{
    public static class Message
    {
        //Domain
        public static string RegisterSuccess => "Created";
        public static string RegisterFailed => "Please check Email and Password failed";

        //Invalid 
        public static string InvalidCredens => "Email or Password is invalid";
        public static string InvalidEmail => "Email is invalid";
        public static string InvalidPassword => "Password is invalid";
        public static string InvalidRefreshToken => "Invalid refresh token";

        //NotFound
        public static string RefreshTokenNotFound => "Refresh token not found";
        public static string UserNotFound => "User not found";
        public static string CredensWhiteSpace => "Plese check Username and Password";
        public static string CourseNameNoteFound => "Course name is not found";

        //Already
        public static string NameAlready => "Name already exists";
        public static string EmailAlready => "Email already exists";

    }
}
