using System;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;

namespace Task2
{
    public class SimpleBinder
    {
        private const BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        private static SimpleBinder _instance;

        private SimpleBinder() {}

        public static SimpleBinder GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SimpleBinder();
            }
            return _instance;
        }

        public T Bind<T>(Dictionary<string, string> dict) where T : new()
        {
            if(dict == null)
            {
                return new T();
            }
            var objInstance = new T();
            var caseIngonreDict = new Dictionary<string, string>(dict, StringComparer.CurrentCultureIgnoreCase);

            var type = objInstance.GetType();

            foreach (var prop in type.GetProperties(_flags))
            {
                if (caseIngonreDict.TryGetValue(prop.Name, out string value))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(objInstance, value);
                    }
                    if (prop.PropertyType == typeof(int))
                    {
                        if (int.TryParse(value, out int res))
                        {
                            prop.SetValue(objInstance, res);
                        }
                    }
                    if (prop.PropertyType == typeof(double))
                    {
                        if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double res))
                        {
                            prop.SetValue(objInstance, res);
                        }
                    }
                }
            }

            foreach (var field in type.GetFields(_flags))
            {
                if (caseIngonreDict.TryGetValue(field.Name, out string value))
                {
                    if (field.FieldType == typeof(string))
                    {
                        field.SetValue(objInstance, value);
                    }
                    if (field.FieldType == typeof(int))
                    {
                        if (int.TryParse(value, out int res))
                        {
                            field.SetValue(objInstance, res);
                        }
                    }
                    if (field.FieldType == typeof(double))
                    {
                        if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double res))
                        {
                            field.SetValue(objInstance, res);
                        }
                    }
                }
            }

            return objInstance;
        }
    }
}
