using Glamdring.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamdring.Repositories
{
    public class MongoDbItemsRepository : IRepository
    {
        private const string databaseName = "glamdring";
        private const string collectionName = "characters";
        private readonly IMongoCollection<Character> collection;
        private readonly FilterDefinitionBuilder<Character> filterBuilder = Builders<Character>.Filter;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            collection = database.GetCollection<Character>(collectionName);
        }
        public async Task CreateItemAsync(Character c) => await collection.InsertOneAsync(c);
        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(c => c.Id, id);
            await collection.DeleteOneAsync(filter);
        }
        public async Task<Character> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(c => c.Id, id);
            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Character>> GetItemsAsync() => await collection.Find(new BsonDocument()).ToListAsync();
        public async Task UpdateItemAsync(Character c)
        {
            var filter = filterBuilder.Eq(existingCharacter => existingCharacter.Id, c.Id);
            await collection.ReplaceOneAsync(filter, c);
        }
    }
}