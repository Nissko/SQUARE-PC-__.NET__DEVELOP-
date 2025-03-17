using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using squarePC.Application.Application.Extensions;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Infrastructure.Repositories.Cpu;

namespace squarePC.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSquarePcCollectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<SquarePcContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreSqlDatabase")));
            
            services.AddScoped<ISquarePcContext>(provider => provider.GetService<SquarePcContext>());
            services.AddScoped<ICpuRepository, CpuRepository>();
            
            services.AddApplication();


            return services;
        }
    }
}