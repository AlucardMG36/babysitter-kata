using BabysitterKata.Core.Accessors;
using BabysitterKata.Core.Data;
using BabysitterKata.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        // NOTE: If we need more information passed in than the connection string, create a DataAccessOptions class
        //       that contains all of those values and change this method to take an Action<DataAccessOptions> parameter
        //       just like other extensions methods are doing.

        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<BabysitterDBContext>(options =>
            {
                options.UseInMemoryDatabase("BabysitterKata");
            });

            services.AddScoped<IBabysitterAccessor, BabysitterRepository>()
                    .AddScoped<IBabysitterRepository, BabysitterRepository>();

            return services;
        }
    }
}
