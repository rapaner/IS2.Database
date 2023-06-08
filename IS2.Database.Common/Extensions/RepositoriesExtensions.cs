using IS2.Database.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Reflection;

namespace IS2.Database.Common.Extensions
{
    /// <summary>
    /// Расширения репозиториев
    /// </summary>
    public static class RepositoriesExtensions
    {
        /// <summary>
        /// Добавить репозитории, наследующие интерфейс <see cref="IVersioningRepository{T, U}"/>
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="assembly">Сборка с репозиториями</param>
        public static IServiceCollection AddVersioningRepositories(this IServiceCollection services, Assembly assembly)
        {
            var repositories = GetAllTypesImplementingOpenGenericType(typeof(IVersioningRepository<,>), assembly);
            foreach (var repository in repositories) 
            {
                var @interface = repository.GetInterfaces().FirstOrDefault();
                services.AddScoped(@interface, repository);

            }
            return services;
        }

        /// <summary>
        /// Получение всех типов из сборки <paramref name="assembly"/>, наследующих тип <paramref name="openGenericType"/>
        /// </summary>
        /// <param name="openGenericType">Дженерик тип</param>
        /// <param name="assembly">Сборка</param>
        private static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
        {
            return from x in assembly.GetTypes()
                   from z in x.GetInterfaces()
                   let y = x.BaseType
                   where
                   !x.IsInterface &&
                   ((y != null && y.IsGenericType &&
                   openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                   (z.IsGenericType &&
                   openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition())))
                   select x;
        }
    }
}