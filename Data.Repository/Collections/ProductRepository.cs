using Entities.Model.Common;
using Entities.Model.Parameters;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbGenericRepository;
using SharpCompress.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Collections
{
    public class ProductRepository : IProductRepository
    {
        protected readonly IMongoDbContext context;
        private IMongoCollection<Product> collection;

        public ProductRepository(IMongoDBRepository context)
        {
            this.context = context.GetContext();
            collection = this.context.GetCollection<Product>();
        }

        public async Task AddAsync(Product entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task AddManyAsync(List<Product> entity)
        {
            await collection.InsertManyAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, id);
            return await collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, entity.Id);
            await collection.ReplaceOneAsync(filter, entity);
        }

        public async Task UpdateManyAsync(List<Product> entities)
        {
            var updates = new List<WriteModel<Product>>();
            foreach (var item in entities)
            {
                var filter = Builders<Product>.Filter.Eq(s => s.Id, item.Id);
                updates.Add(new ReplaceOneModel<Product>(filter,item));
            }
            await collection.BulkWriteAsync(updates, new BulkWriteOptions() { IsOrdered=false});
        }
    }
}
