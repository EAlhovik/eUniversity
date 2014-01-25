using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace eUniversity.Common.Utilities
{
    public class EnumHelper
    {
        /// <summary>
        /// Gets enum values into multiselection
        /// </summary>
        /// <param name="enumType">Type of the enum</param>
        /// <returns>Multiselection model</returns>
        public static IEnumerable<KeyValuePair<string, string>> GetEnumValues(Type enumType)
        {
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Type unde = Enum.GetUnderlyingType(enumType);

            IEnumerable<Enum> enumItems = Enum.GetValues(enumType).Cast<Enum>();

            IEnumerable<KeyValuePair<string, string>> items = enumItems.Select(item =>
                                                                            new KeyValuePair<string, string>(
//                                                                                item.ToString(),
                                                                                Convert.ChangeType(item, unde).ToString(),
                                                                                GetEnumDescription(item)));

            return items;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        } 
    }
}