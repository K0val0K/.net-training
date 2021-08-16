using System;
using System.Reflection;
using System.Linq;

namespace Task1Lib
{
    public class Logger
    {
        private const BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        private readonly string _fileName;

        public Logger(string filename)
        {
            _fileName = filename;
        }

        public void Track(object obj)
        {
            var dataWriter = new DataWriter(_fileName);

            var type = obj.GetType();
            if(Attribute.IsDefined(type, typeof(TrackingEntityAttribute))) 
            {
                var fields = type.GetFields(_flags)
                    .Where(f => f.IsDefined(typeof(TrackingPropertyAttribute)))
                    .ToDictionary(f => f.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName ?? f.Name, f => f.GetValue(obj));

                var properties = type.GetProperties(_flags)
                    .Where(p => p.IsDefined(typeof(TrackingPropertyAttribute)))
                    .ToDictionary(p => p.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName ?? p.Name, p => p.GetValue(obj));

                var members = fields.Concat(properties)
                    .ToDictionary(x => x.Key, x => x.Value);

                dataWriter.Append(members);

                //вместе с именем типа
                //var withObjName = new Dictionary<string, Dictionary<string, object>>()
                //{
                //    {obj.GetType().Name, members},
                //};
                //dataWriter.Append(withObjName);
            }

        }
    }
}
