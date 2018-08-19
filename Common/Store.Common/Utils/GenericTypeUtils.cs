using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Store.Common.Utils
{
    public static class GenericTypeUtils<T>
    {
        private static IEnumerable<PropertyInfo> _properties;

        public static IEnumerable<PropertyInfo> Properties
        {
            get
            {
                if (_properties == null)
                    _properties = typeof(T).GetProperties();

                return _properties;
            }

            set => _properties = value;
        }

        public static PropertyInfo GetProperty(string name)
        {
            return Properties.FirstOrDefault(p => p.Name == name);
        }
    }
}