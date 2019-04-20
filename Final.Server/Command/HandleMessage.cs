using System;

namespace Final.Server.Common
{
    public class RegisterException : Exception
    {
        public RegisterException(string message) : base(message) { }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message){}
    }

    public class EmailException : Exception
    {
        public EmailException(string message) : base(message) { }
    }

    public class WhiteSpaceException :Exception
    {
        public WhiteSpaceException(string message) : base(message){}
    }

    public class RefreshTokenException : Exception
    {
        public RefreshTokenException(string message) : base(message) {}
    }

    public class CourseNameException : Exception
    {
        public CourseNameException(string message) : base(message) {}
    }

    public class AvoidAuthLocal : Exception
    {
        public AvoidAuthLocal(string message) : base(message) {}
    }
}
