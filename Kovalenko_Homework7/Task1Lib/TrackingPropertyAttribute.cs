using System;

namespace Task1Lib
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public TrackingPropertyAttribute() { }

        public TrackingPropertyAttribute(string propertyName) => PropertyName = propertyName;

    }
}
