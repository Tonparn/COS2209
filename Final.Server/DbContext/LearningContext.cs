using Final.Server.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Final.Server.DbContext
{
    public class LearningContext
    {
        private readonly IMongoDatabase _mongodb;

        public LearningContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (!string.IsNullOrEmpty(client.ToString()))
            {
                _mongodb = client.GetDatabase(settings.Value.Database);
            }
        }

        internal IMongoCollection<Learning> Learning => _mongodb.GetCollection<Learning>("learnings");
    }
}
