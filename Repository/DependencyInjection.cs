using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISubLocationRepository, SubLocationRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
