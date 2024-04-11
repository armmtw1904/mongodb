using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mongodb.Repository.Entities;
using Microsoft.Extensions.Options;

namespace mongodb.Repository.Helpers
{
    public class MongodbDriver : IMongodbDriver
    {
        private readonly ILogger<MongodbDriver> _logger;
        private readonly MongoCnn _mongocnn;
        private readonly IMongoDatabase _database;

        public MongodbDriver(ILogger<MongodbDriver> logger,
            IOptions<MongoCnn> mongocnn)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._mongocnn = mongocnn.Value;;

            try
            {
                if (!string.IsNullOrEmpty(_mongocnn.connectionString))
                {
                    MongoClientSettings settings = MongoClientSettings.FromConnectionString(_mongocnn.connectionString);
                    MongoCredential credential = MongoCredential.CreateCredential("admin", _mongocnn.username, _mongocnn.password);
                    settings.Credential = credential;
                    var client = new MongoClient(settings);
                    _database = client.GetDatabase(_mongocnn.database);
                    _logger.LogInformation("created mongo client");
                }
            }
            catch (Exception)
            {
                _logger.LogError("failed to create mongo client");
                throw new Exception("failed to create mongo client");
            }
        }

        public IMongoDatabase database { get { return _database; } }
    }
}
