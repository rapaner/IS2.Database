using IS2.Database.Common.Model;

namespace IS2.Database.ConfigurationData.Model
{
    /// <summary>
    /// Тип версии
    /// </summary>
    public class VersionTypeEntity : Enumeration
    {
        /// <summary>
        /// Черновик
        /// </summary>
        public static VersionTypeEntity Draft = new(1, "Черновик");

        /// <summary>
        /// Подтверждена
        /// </summary>
        public static VersionTypeEntity Confirmed = new(2, "Подтверждена");

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        protected VersionTypeEntity(int id, string name) : base(id, name)
        {
        }
    }
}