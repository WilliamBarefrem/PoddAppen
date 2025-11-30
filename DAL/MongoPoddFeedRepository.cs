using System.Collections.Generic;
using System.Threading.Tasks;
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

       
        public async Task AddAsync(PoddFeed item)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                await _collection.InsertOneAsync(session, item);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

     
        public async Task<List<PoddFeed>> GetAllAsync()
        {
            var cursor = await _collection.FindAsync(_ => true);
            return await cursor.ToListAsync();
        }

        
        public async Task<PoddFeed?> GetByIdAsync(string id)
        {
            var filter = Builders<PoddFeed>.Filter.Eq(f => f.Id, id);
            var cursor = await _collection.FindAsync(filter);
            return await cursor.FirstOrDefaultAsync();
        }

       
        public async Task<bool> UpdateAsync(PoddFeed item)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var filter = Builders<PoddFeed>.Filter.Eq(f => f.Id, item.Id);
                var result = await _collection.ReplaceOneAsync(session, filter, item);
                await session.CommitTransactionAsync();
                return result.ModifiedCount == 1;
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

       
        public async Task<bool> DeleteAsync(string id)
        {
            using var session = await _client.StartSessionAsync();
            session.StartTransaction();
            try
            {
                var filter = Builders<PoddFeed>.Filter.Eq(f => f.Id, id);
                var result = await _collection.DeleteOneAsync(session, filter);
                await session.CommitTransactionAsync();
                return result.DeletedCount == 1;
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }
    }
}