using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class PoddFeed
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ?Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RssUrl { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty; 
    }
}

