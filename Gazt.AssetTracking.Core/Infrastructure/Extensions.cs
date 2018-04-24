using System;
using System.ComponentModel;

namespace Gazt.AssetTracking.Core.Infrastructure
{
    public static class Extensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// Converts an <see cref="Enum"/> value to a string if it is annotated with a <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>
        /// The <see cref="DescriptionAttribute"/> string of the corresponding <see cref="Enum"/> member, or an empty string if no <see cref="DescriptionAttribute"/> is present.
        /// </returns>
        public static string ToDescription(this Enum enumeration) // ToDescription is used in CacheControlDecorator in Release mode.
        {
            var enumValue = enumeration.ToString();
            var enumType = enumeration.GetType();

            var attribute = enumType.GetField(enumValue).GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attribute == null || attribute.Length == 0)
            {
                return string.Empty;
            }

            return attribute[0].Description;
        }
    }
}
