using MediatR;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
        {
            //This enables MediatR and scans the current assembly for all types that implement the MediatR interfaces
            services.AddMediatR(typeof(IServiceCollectionExtensions).Assembly);

            return services;
        }
    }
}
