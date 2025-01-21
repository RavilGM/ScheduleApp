using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppBusinessLogic.HelpersLogic
{
    public static class EnumExtensions
    {
        public static IList ToList(this Type type)
        {
            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);
            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, value.GetEnumDescription()));
            }
            return list;

        }
        public static string GetEnumDescription(this Enum input)
        {
            FieldInfo fi = input.GetType().GetField(input.ToString());
            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[]
                attributes && attributes.Any())
            {
                return attributes.First().Description;
            }
            return input.ToString();
        }
    }
}
