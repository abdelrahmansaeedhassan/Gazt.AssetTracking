using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gazt.AssetTracking.Core.Extensions
{
    public static class EnumExtentions
    {
        public static string ToDescription(this Enum value)
        {
            // variables  
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // return  
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
