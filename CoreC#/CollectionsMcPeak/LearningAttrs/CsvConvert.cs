using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAttrs
{
    public static class CsvConvert
    {
        public static string ToCsv(object obj)
        {
            var type = obj.GetType();
            var attrType = typeof(DisplayOrderAttribute);
            var props = type.GetProperties()
                .Where(p => Attribute.IsDefined(p, attrType))
                .ToArray();

            var csv = new string[props.Length];

            foreach (var prop in props)
            {
                var attrs = prop.GetCustomAttributes(attrType, true)
                    .Cast<DisplayOrderAttribute>().ToArray();

                foreach (var attr in attrs)
                {
                    var value = prop.GetValue(obj);
                    var pos = attr.Position;

                    csv[pos] = value?.ToString() ?? string.Empty;
                }
            }

            return string.Join(",", csv); 
        }
    }
}
