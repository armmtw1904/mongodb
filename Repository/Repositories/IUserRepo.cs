
using mongodb.Repository.Entities;

namespace mongodb.Repository
{
    public interface IUserRepo
    {
        Task<int> TestCnnAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(string id);
        Task<int> InsertDummyUsers();
        Task<bool> InsertUser();
        Task<bool> UpdateUser();
    }
}