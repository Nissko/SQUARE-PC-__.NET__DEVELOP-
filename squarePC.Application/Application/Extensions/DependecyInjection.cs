using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace squarePC.Application.Application.Extensions
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}