using Microsoft.Extensions.DependencyInjection;

namespace mongodb.Repository.Helpers
{
    public static class RegisterRepos
    {
        public static void RegisterRepoDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMongodbDriver, MongodbDriver>();
            services.AddTransient<IUserRepo, UserRepo>();
        }
    }
}
