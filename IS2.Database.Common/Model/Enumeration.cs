using System.Reflection;

namespace IS2.Database.Common.Model
{
    /// <summary>
    /// Перечисление
    /// </summary>
    public abstract class Enumeration : IComparable, IConvertible
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Конвертация в стркоу
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        /// <summary>
        /// Получить весьт список
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Разница по модулю
        /// </summary>
        /// <param name="firstValue">Первое значение</param>
        /// <param name="secondValue">Второе значение</param>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Идентификатор</param>
        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }

        /// <summary>
        /// Получить объект по названию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName">Название</param>
        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }

        /// <summary>
        /// Приведение значения к объекту перечисления
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="value">Значение</param>
        /// <param name="description">Описание</param>
        /// <param name="predicate">Предикат</param>
        /// <exception cref="InvalidOperationException"></exception>
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

            return matchingItem;
        }

        /// <summary>
        /// Сравнение
        /// </summary>
        /// <param name="other">Второй объект</param>
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        #region IConvertible

        /// <summary>
        /// Получить код типа
        /// </summary>
        public TypeCode GetTypeCode() => Id.GetTypeCode();

        /// <inheritdoc/>
        /// <exception cref="NotImplementedException"></exception>
        public bool ToBoolean(IFormatProvider provider) => throw new NotImplementedException();

        /// <inheritdoc/>
        public byte ToByte(IFormatProvider provider) => (byte)Id;

        /// <inheritdoc/>
        public char ToChar(IFormatProvider provider) => Name[0];

        /// <inheritdoc/>
        /// <exception cref="NotImplementedException"></exception>
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public decimal ToDecimal(IFormatProvider provider) => Id;

        /// <inheritdoc/>
        public double ToDouble(IFormatProvider provider) => Id;

        /// <inheritdoc/>
        public short ToInt16(IFormatProvider provider) => ((IConvertible)Id).ToInt16(provider);

        /// <inheritdoc/>
        public int ToInt32(IFormatProvider provider) => Id;

        /// <inheritdoc/>
        public long ToInt64(IFormatProvider provider) => Id;

        /// <inheritdoc/>
        public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Id).ToSByte(provider);

        /// <inheritdoc/>
        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public string ToString(IFormatProvider provider) => Name;

        /// <inheritdoc/>
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType.Equals(typeof(int)))
            {
                return ToInt32(provider);
            }
            else if (conversionType.Equals(typeof(long)))
            {
                return ToInt64(provider);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc/>
        public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Id).ToUInt16(provider);

        /// <inheritdoc/>
        public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Id).ToUInt32(provider);

        /// <inheritdoc/>
        public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)Id).ToUInt64(provider);

        #endregion IConvertible
    }
}