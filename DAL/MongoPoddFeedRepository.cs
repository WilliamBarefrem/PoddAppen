using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BL;
using Models;
using MongoDB.Driver;

namespace DAL
{
    public class MongoPoddFeedRepository : IRepository<PoddFeed>
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<PoddFeed> _collection;

        public MongoPoddFeedRepository(string connectionString,
                                       string databaseName = "PoddDb",
                                       string collectionName = "PoddFeeds")
        {
            _client = new MongoClient(connectionString);
            var db = _client.GetDatabase(databaseName);
            _collection = db.GetCollection<PoddFeed>(collectionName);
        }

        // CREATE
        public void Add(PoddFeed item)
        {
            using var session = _client.StartSession();
            session.StartTransaction();
            try
            {
                _collection.InsertOne(session, item);
                session.CommitTransaction();
            }
            catch
            {
                session.AbortTransaction();
                throw;
            }
        }

        // READ – alla
        public List<PoddFeed> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        // READ – en
        public PoddFeed? GetById(string id)
        {
            var filter = Builders<PoddFeed>.Filter.Eq(f => f.Id, id);
            return _collection.Find(filter).FirstOrDefault();
        }

        // UPDATE
        public bool Update(PoddFeed item)
        {
            using var session = _client.StartSession();
            session.StartTransaction();
            try
            {
                var filter = Builders<PoddFeed>.Filter.Eq(f => f.Id, item.Id);
                var result = _collection.ReplaceOne(session, filter, item);
                session.CommitTransaction();
                return result.ModifiedCount == 1;
            }
            catch
            {
                session.AbortTransaction();
                throw;
            }
        }

        // DELETE
        public bool Delete(string id)
        {
            using var session = _client.StartSession();
            session.StartTransaction();
            try
            {
                var filter = Builders<PoddFeed>.Filter.Eq(f => f.Id, id);
                var result = _collection.DeleteOne(session, filter);
                session.CommitTransaction();
                return result.DeletedCount == 1;
            }
            catch
            {
                session.AbortTransaction();
                throw;
            }
        }
    }
}
