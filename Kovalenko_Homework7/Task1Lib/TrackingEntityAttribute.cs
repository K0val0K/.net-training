using System;

namespace Task1Lib
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TrackingEntityAttribute : Attribute
    {
    }
}
