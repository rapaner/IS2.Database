namespace IS2.Database.ConfigurationData.Model
{
    /// <summary>
    /// Ветка
    /// </summary>
    public class Branch
    {
        #region Поля

        protected int? _requestedHashCode;

        #endregion Поля

        #region Свойства

        /// <summary>
        /// Идентификатор ветки
        /// </summary>
        public Guid BranchId { get; protected set; }

        /// <summary>
        /// Название ветки
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Версии
        /// </summary>
        public List<Version> Versions { get; } = new();

        /// <summary>
        /// Удалена?
        /// </summary>
        public bool IsDeleted { get; protected set; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Установить название
        /// </summary>
        /// <param name="name">Название</param>
        public void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Установить признак удаления
        /// </summary>
        /// <param name="isDeleted">Удалена?</param>
        public void SetIsDeleted(bool isDeleted = true)
        {
            IsDeleted = isDeleted;
        }

        #endregion Методы

        #region Служебные методы

        public bool IsTransient()
        {
            return BranchId == default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Branch))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Branch item = (Branch)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.BranchId == BranchId
                    && item.Name == Name
                    && item.IsDeleted == IsDeleted;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = BranchId.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(Branch left, Branch right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Branch left, Branch right)
        {
            return !(left == right);
        }

        #endregion Служебные методы
    }
}