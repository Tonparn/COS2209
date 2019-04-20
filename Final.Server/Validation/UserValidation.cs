using Final.Server.Common;
using Final.Shared;
using System;
using System.Text.RegularExpressions;

namespace Final.Server.Validation
{
    public static class UserValidation
    {
        public static void ValidateRegister(UserParam user)
        {
            if(!validateEmail(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new EmailException(Message.InvalidEmail);
            }
        }

        public static void ValidateLogin(Credentials user)
        {
            if(string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new WhiteSpaceException(Message.CredensWhiteSpace);
            }
        }

        private static bool validateEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}