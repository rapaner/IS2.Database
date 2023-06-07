using IS2.Database.Common.Model;

namespace IS2.Database.ConfigurationData.Model
{
    /// <summary>
    /// Настройки
    /// </summary>
    public class SettingEntity : VersioningEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        protected SettingEntity(Guid settingId, string name, Guid versionId) : base(versionId)
        {
            SettingId = settingId;
            Name = name;
        }

        #region Свойства

        /// <summary>
        /// Идентификатор настройки
        /// </summary>
        public Guid SettingId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static SettingEntity New(string name, Guid versionId)
        {
            return new SettingEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static SettingEntity NewFromExisting(SettingEntity entity, Guid versionId)
        {
            var setting = new SettingEntity(entity.SettingId, entity.Name, versionId);
            return setting;
        }

        #endregion Методы

        #region Методы изменения свойств

        /// <summary>
        /// Изменить идентификатор настройки
        /// </summary>
        /// <param name="settingId">Идентификатор настройки</param>
        public void SetSettingId(Guid settingId)
        {
            SettingId = settingId;
        }

        /// <summary>
        /// Изменить название
        /// </summary>
        /// <param name="name">Название</param>
        public void SetName(string name)
        {
            Name = name;
        }

        #endregion Методы изменения свойств

        #region Служебные методы

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SettingEntity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            SettingEntity item = (SettingEntity)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.SettingId == SettingId
                    && item.Name == Name;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(SettingEntity left, SettingEntity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(SettingEntity left, SettingEntity right)
        {
            return !(left == right);
        }

        #endregion Служебные методы
    }
}