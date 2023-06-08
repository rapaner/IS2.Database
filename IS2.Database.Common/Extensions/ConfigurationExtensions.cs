using Microsoft.Extensions.Configuration;

namespace IS2.Database.Common.Extensions
{
    /// <summary>
    /// Расширения конфигурации
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Получить строку подключения
        /// </summary>
        /// <param name="configuration">Конфигурация</param>
        /// <param name="name">Название</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetRequiredConnectionString(this IConfiguration configuration, string name) =>
            configuration.GetConnectionString(name) ?? throw new InvalidOperationException($"Отсутствует значение конфигурации: {(configuration is IConfigurationSection s ? s.Path + ":ConnectionStrings:" + name : "ConnectionStrings:" + name)}");
    }
}