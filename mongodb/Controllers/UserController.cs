using Microsoft.AspNetCore.Mvc;
using mongodb.Repository;
using mongodb.Repository.Entities;

namespace mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepo userRepo, ILogger<UserController> logger)
        {
            this._userRepo = userRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("test-cnn")]
        public async Task<int> TestConnection()
        {
            return await _userRepo.TestCnnAsync();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<User> GetAllUsers(string userId)
        {
            return await _userRepo.GetByIdAsync(userId);
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepo.GetAllUsersAsync();
        }

        [HttpGet]
        [Route("insert-test-data")]
        public async Task<int> GetUserById()
        {
            return await _userRepo.InsertDummyUsers();
        }
    }
}