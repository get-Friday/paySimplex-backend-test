using Microsoft.Extensions.DependencyInjection;
using paySimplex.Domain.Interfaces.Services;
using paySimplex.Domain.Services;

namespace paySimplex.DI
{
    public static class ServicesIOC
    {
        public static IServiceCollection RegisterServices(this IServiceCollection builder)
        {
            return builder
                .AddScoped<IChoreService, ChoreService>();
        }
    }
}
