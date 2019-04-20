using Final.Server.Model;
using MongoDB.Driver;

namespace Final.Server.Common
{
    public static class FindUser
    {

        public static FilterDefinition<User> Email(string email) 
            => Builders<User>.Filter.Eq(x => x.Email, email);

        public static FilterDefinition<User> Name(string name) 
            => Builders<User>.Filter.Eq(x => x.Name, name);

        public static FilterDefinition<User> RefreshToken(string refreshToken) 
            => Builders<User>.Filter.Eq(x => x.RefreshToken, refreshToken);
    }

    public static class UpdateUser
    {
        public static UpdateDefinition<User> RemoveRefreshToken() 
            => Builders<User>.Update.Set(s => s.RefreshToken, "");

        public static UpdateDefinition<User> CreateRefreshToken(string refreshToken)
         => Builders<User>.Update.Set(s => s.RefreshToken, refreshToken);
    }
}
