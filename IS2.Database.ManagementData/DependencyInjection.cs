using IS2.Database.Common.Extensions;
using IS2.Database.ManagementData.Repositories;
using IS2.Database.ManagementData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IS2.Database.ManagementData
{
    /// <summary>
    /// Методы для регистрации зависимостей
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Добавить сервисы блока управленческих данных
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
        public static IServiceCollection AddManagementDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ManagementDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetRequiredConnectionString("ManagementData"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });
            });

            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddVersioningRepositories(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}