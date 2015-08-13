using System;
using System.Reflection;

namespace Utilities.ObjectDifferentiation
{
    /// <summary>
    /// The generic Difference between two objects, the vagues possible difference
    /// </summary>
    public class Difference
    {
         
    }

    public class ValueDifference : Difference
    {
        public object A { get; set; }
        public object B { get; set; }

        public ValueDifference(Object A, Object B)
        {
            this.A = A;
            this.B = B;
        }
    }


    public class TypeDifference : Difference
    {
        public Type Type { get; set; }
        public PropertyInfo PropertyInfo{ get; set; }

        public TypeDifference( Type type , PropertyInfo propertyInfo)
        {
            this.Type = type;
            this.PropertyInfo = propertyInfo;
        }
    }

    
}