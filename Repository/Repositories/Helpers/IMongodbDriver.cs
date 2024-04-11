
using MongoDB.Driver;

namespace mongodb.Repository.Helpers
{
    public interface IMongodbDriver
    {
        IMongoDatabase database { get; }
    }
}