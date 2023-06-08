using IS2.Database.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IS2.Database.ProjectData
{
    /// <summary>
    /// Методы для регистрации зависимостей
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Добавить сервисы блока проектных данных
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
        public static IServiceCollection AddProjectDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetRequiredConnectionString("ProjectData"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });
            });

            services.AddVersioningRepositories(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}