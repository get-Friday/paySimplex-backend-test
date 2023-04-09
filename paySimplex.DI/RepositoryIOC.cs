using Microsoft.Extensions.DependencyInjection;
using paySimplex.Domain.Interfaces.Repositories;
using paySimplex.Infra.Data;
using paySimplex.Infra.Data.Repositories;

namespace paySimplex.DI
{
    public static class RepositoryIOC
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection builder)
        {
            return builder
                .AddDbContext<PaySimplexDbContext>()
                .AddScoped<IChoreRepository, ChoreRepository>();
        }
    }
}
