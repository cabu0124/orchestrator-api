using Entities.Model.Parameters;
using MongoDB.Driver;
using MongoDbGenericRepository;

namespace Data.Repository
{
    public class MongoDBRepository : BaseMongoRepository, IMongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBRepository(string dbConnection, string dbNamer = null) : base(dbConnection, dbNamer)
        {
            MapMongoDBContext.MapProduct();
        }

        public IMongoDbContext GetContext()
        {
            return this.MongoDbContext;
        }
    }
}
