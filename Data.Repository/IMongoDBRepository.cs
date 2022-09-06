using MongoDbGenericRepository;

namespace Data.Repository
{
    public interface IMongoDBRepository
    {
        IMongoDbContext GetContext();
    }
}
