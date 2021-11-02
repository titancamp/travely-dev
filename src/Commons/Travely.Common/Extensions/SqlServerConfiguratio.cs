﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace TourManager.Api.Bootstrapper
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection AddSqlServer<TDbContext>(this IServiceCollection services,
            string connectionString,
            string assemblyName) where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(
               options => options.UseSqlServer(
                       connectionString,
                       x => x.MigrationsAssembly(assemblyName)));

            return services;
        }

        public static IApplicationBuilder ApplyDatabaseMigrations<TDbContext>(this IApplicationBuilder applicationBuilder) where TDbContext : DbContext
        {
            using var serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope == null) return applicationBuilder;
            var context = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();

            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}