﻿using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Application.Services;
using AutoglassChallenge.Domain.Interfaces;
using AutoglassChallenge.Intra.Data.DataContext;
using AutoglassChallenge.Intra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

#nullable disable
namespace AutoglassChallenge.Intra.Data.DataConfig
{
    public static class DataConfig
    {
        public static IServiceCollection AddDataConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //basic IOC layer
            services
                   .AddDbContextPool<ApplicationDbContext>(opts => opts
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                   .UseSqlServer(configuration
                   .GetConnectionString("SQLConnection"), b => b
                   .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //add repositories here
            services.TryAddScoped(typeof(IProductRepository), typeof(ProductRepository));
            
            

            //add services here
            services.TryAddScoped(typeof(IProductService), typeof(ProductService));

            return services;

        }

    }
}
