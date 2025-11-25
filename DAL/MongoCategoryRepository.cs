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
    public class MongoCategoryRepository : IRepository<Category>
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<Category> _collection;

        public MongoCategoryRepository(string connectionString,
                                       string databaseName = "PoddDb",
                                       string collectionName = "Categories")
        {
            _client = new MongoClient(connectionString);
            var db = _client.GetDatabase(databaseName);
            _collection = db.GetCollection<Category>(collectionName);
        }

        public void Add(Category item)
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

        public List<Category> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public Category? GetById(string id)
        {
            var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public bool Update(Category item)
        {
            using var session = _client.StartSession();
            session.StartTransaction();
            try
            {
                var filter = Builders<Category>.Filter.Eq(c => c.Id, item.Id);
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

        public bool Delete(string id)
        {
            using var session = _client.StartSession();
            session.StartTransaction();
            try
            {
                var filter = Builders<Category>.Filter.Eq(c => c.Id, id);
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

