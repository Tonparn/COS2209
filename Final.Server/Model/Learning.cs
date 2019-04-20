using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Final.Server.Model
{
    [BsonIgnoreExtraElements]
    internal class Learning
    {
        [BsonId]
        [BsonElement("_id")]
        public string CourseName;

        public IEnumerable<Lesson> Lesson;
    }; 

    [BsonIgnoreExtraElements]
    internal class Lesson
    {
        [BsonElement("Name")]
        public string Name;

        [BsonElement("Chapter")]
        public string Chapter;

        [BsonElement("Html")]
        public string Html;

        [BsonElement("Editor")]
        public bool Editor;

        [BsonElement("Hint")]
        public string Hint;
    }
}