using IS2.Database.Common.Extensions;
using IS2.Database.ConfigurationData.Repositories;
using IS2.Database.ConfigurationData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IS2.Database.ConfigurationData
{
    /// <summary>
    /// Методы для регистрации зависимостей
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Добавить сервисы блока конфигурационных данных
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
        public static IServiceCollection AddConfigurationDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConfigurationDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetRequiredConnectionString("ConfigurationData"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });
            });

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IVersionRepository, VersionRepository>();
            services.AddVersioningRepositories(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}