﻿using IS2.Database.Common.Model;

namespace IS2.Database.ConfigurationData.Model
{
    /// <summary>
    /// Настройка пользователя
    /// </summary>
    public class UserSettingEntity : VersioningEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settingId">Идентификатор настройки</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="value">Значение</param>
        /// <param name="versionId">Идентификатор версии</param>
        public UserSettingEntity(Guid settingId, Guid userId, string value, Guid versionId) : base(versionId)
        {
            SettingId = settingId;
            UserId = userId;
            Value = value;
        }

        #region Свойства

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid UserSettingId { get; protected set; }

        /// <summary>
        /// Идентификатор настройки
        /// </summary>
        public Guid SettingId { get; protected set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; protected set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; protected set; }

        #endregion Свойства

        #region Служебные методы

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is UserSettingEntity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            UserSettingEntity item = (UserSettingEntity)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.UserSettingId == UserSettingId
                    && item.SettingId == SettingId
                    && item.UserId == UserId
                    && item.Value == Value;
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

        public static bool operator ==(UserSettingEntity left, UserSettingEntity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(UserSettingEntity left, UserSettingEntity right)
        {
            return !(left == right);
        }

        #endregion Служебные методы
    }
}