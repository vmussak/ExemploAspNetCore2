using System;
using System.Data;

namespace WebApiExemplo.Repository.Core.Extensions
{
    public static class DataReaderExtension
    {
        #region ☼ Return Not NUll ☼

        public static int ReadAsInt(this IDataReader reader, string columnName)
        {
            return reader.GetInt32(reader.GetOrdinal(columnName));
        }

        public static short ReadAsShort(this IDataReader reader, string columnName)
        {
            return reader.GetInt16(reader.GetOrdinal(columnName));
        }

        public static byte ReadAsByte(this IDataReader reader, string columnName)
        {
            return reader.GetByte(reader.GetOrdinal(columnName));
        }

        public static long ReadAsLong(this IDataReader reader, string columnName)
        {
            return reader.GetInt64(reader.GetOrdinal(columnName));
        }

        public static string ReadAsString(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                 ? default(string)
                 : reader.GetString(reader.GetOrdinal(columnName));
        }

        public static decimal ReadAsDecimal(this IDataReader reader, string columnName)
        {
            return reader.GetDecimal(reader.GetOrdinal(columnName));
        }

        public static DateTime ReadAsDateTime(this IDataReader reader, string columnName)
        {
            return reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        public static bool ReadAsBool(this IDataReader reader, string columnName)
        {
            return reader.GetBoolean(reader.GetOrdinal(columnName));
        }

        #endregion

        #region ☼ Return Null ☼

        public static int? ReadAsIntNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(int?)
                : reader.GetInt32(reader.GetOrdinal(columnName));
        }

        public static long? ReadAsLongNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(long?)
                : reader.GetInt64(reader.GetOrdinal(columnName));
        }

        public static byte? ReadAsByteNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(byte?)
                : reader.GetByte(reader.GetOrdinal(columnName));
        }

        public static short? ReadAsShortNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(short?)
                : reader.GetInt16(reader.GetOrdinal(columnName));
        }

        public static decimal? ReadAsDecimalNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(decimal?)
                : reader.GetDecimal(reader.GetOrdinal(columnName));
        }

        public static DateTime? ReadAsDateTimeNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(DateTime?)
                : reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        public static bool? ReadAsBoolNull(this IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName))
                ? default(bool?)
                : reader.GetBoolean(reader.GetOrdinal(columnName));
        }

        #endregion
    }
}
