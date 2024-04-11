using Microsoft.Extensions.Logging;
using mongodb.Repository.Entities;
using mongodb.Repository.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongodb.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger<UserRepo> _logger;
        private List<string> hobbies = new List<string> { "travel", "music", "movies", "food" };

        public UserRepo(IMongodbDriver mongodbDriver, ILogger<UserRepo> logger)
        {
            this._database = mongodbDriver.database;
            this._logger = logger;
        }

        public async Task<int> TestCnnAsync()
        {
            try
            {
                var resp = await _database.RunCommandAsync((Command<BsonDocument>)@"{ping:1}");
                var val = resp.GetValue("ok").ToInt32();
                return val;
            }
            catch (Exception e)
            {
                _logger.LogError("database connection error");
            }
            return 0;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                var users = (await _database.GetCollection<User>("users").FindAsync(_ => true)).ToListAsync();
                return await users;
            }
            catch (Exception e)
            {
                _logger.LogError("exception while getting users");
            }
            return null;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("id", id);
            return (await _database.GetCollection<User>("users").FindAsync(f => f.Id == id)).FirstOrDefault();
        }

        public async Task<bool> InsertUser()
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUser()
        {
            return await Task.FromResult(true);
        }

        public async Task<int> InsertDummyUsers()
        {
            try
            {
                var useresCollection = _database.GetCollection<User>("users");
                Random rand = new Random();
                List<User> users = new List<User>();
                for (int i = 0; i < 30; i++)
                {
                    users.Add(new User()
                    {
                        FirstName = $"fname-{i}",
                        LastName = $"fname-{i}",
                        Age = rand.Next(20, 30),
                        Hobbies = generateRandomHobbies()
                    });
                }
                await useresCollection.InsertManyAsync(users);
                return 1;
            }
            catch (Exception e)
            {
                _logger.LogError("error while creating dummy data");
            }

            return 0;
        }
        private List<string> generateRandomHobbies()
        {
            Random rand = new Random();
            var hobby = hobbies[rand.Next(0, 3)];
            return new List<string> { hobby };
        }
    }
}
