using Final.Server.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Final.Server.DbContext
{
    public class UserContext
    {
        private readonly IMongoDatabase _mongodb;

        public UserContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (!string.IsNullOrEmpty(client.ToString()))
            {
                _mongodb = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<User> User => _mongodb.GetCollection<User>("users");
    }
}
