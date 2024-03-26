#nullable disable
using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Application.Profiles;
using AutoglassChallenge.Application.Services;
using AutoglassChallenge.Domain.Interfaces;
using AutoglassChallenge.Intra.Data.DataContext;
using AutoglassChallenge.Intra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AutoglassChallenge.Infra.IoC.DataConfig
{
    public static class DataConfig
    {
        public static IServiceCollection AddDataConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services
                   .AddDbContextPool<ApplicationDbContext>(opts => opts
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                   .UseSqlServer(configuration
                   .GetConnectionString("DefaultConnection"), b => b
                   .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddAutoMapper(typeof(DtoToEntityProfile));

            //add repositories here
            services.TryAddScoped(typeof(IProductRepository), typeof(ProductRepository));



            //add services here
            services.TryAddScoped(typeof(IProductService), typeof(ProductService));

            return services;

        }

    }
}
