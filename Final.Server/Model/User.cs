using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Final.Server.Model
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonElement("Email")]
        public string Email;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Password")]
        public string Password;

        [BsonElement("RefreshToken")]
        public string RefreshToken;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate = DateTime.Now;
    }
}