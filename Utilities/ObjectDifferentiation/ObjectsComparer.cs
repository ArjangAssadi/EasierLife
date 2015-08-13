using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utilities.ObjectDifferentiation
{
    /// <summary>
    /// Finds Differences between two objects
    /// </summary>
    public class ObjectsDifferentiator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectA">The first object to compare.</param>
        /// <param name="objectB">The second object to compre.</param>
        /// <param name="ignoreList">A list of property names to ignore from the comparison.</param>
        public ObjectsDifferentiator()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectA"></param>
        /// <param name="objectB"></param>
        /// <param name="objectOfTypeADifference"></param>
        public object RemoveBFromA(object objectA, object objectB)
        {
            object result = Activator.CreateInstance(objectA.GetType());

            //Foreach Property in A go trough 
            if (objectB == null)
                return result;

                Type objectType;
                objectType = objectA.GetType();

                foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead ) )
                {
                    object valueA;
                    object valueB;

                    valueA = propertyInfo.GetValue(objectA, null);
                    valueB = propertyInfo.GetValue(objectB, null);

                    // if it is a primative type, value type or implements IComparable, just directly try and compare the value
                    if (CanDirectlyCompare(propertyInfo.PropertyType))
                    {
                        if (!AreValuesEqual(valueA, valueB))
                        {
                            //_DiffList.AppendLine(string.Format("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name));
                            _DiffList.Add(new TypeDifference(objectType, propertyInfo));
                            result = false;
                        }
                    }
                    // if it implements IEnumerable, then scan any items
                    else if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        IEnumerable<object> collectionItems1;
                        IEnumerable<object> collectionItems2;
                        int collectionItemsCount1;
                        int collectionItemsCount2;

                        // null check
                        if (valueA == null && valueB != null || valueA != null && valueB == null)
                        {
                            //Console.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                            _DiffList.Add(new TypeDifference(objectType, propertyInfo));
                            result = false;
                        }
                        else if (valueA != null && valueB != null)
                        {
                            collectionItems1 = ((IEnumerable)valueA).Cast<object>();
                            collectionItems2 = ((IEnumerable)valueB).Cast<object>();
                            collectionItemsCount1 = collectionItems1.Count();
                            collectionItemsCount2 = collectionItems2.Count();

                            // check the counts to ensure they match
                            if (collectionItemsCount1 != collectionItemsCount2)
                            {
                                //Console.WriteLine("Collection counts for property '{0}.{1}' do not match.", objectType.FullName, propertyInfo.Name);
                                _DiffList.Add(new TypeDifference(objectType, propertyInfo));
                                result = false;
                            }
                            // and if they do, compare each item... this assumes both collections have the same order
                            else
                            {
                                for (int i = 0; i > collectionItemsCount1; i++)
                                {
                                    object collectionItem1;
                                    object collectionItem2;
                                    Type collectionItemType;

                                    collectionItem1 = collectionItems1.ElementAt(i);
                                    collectionItem2 = collectionItems2.ElementAt(i);
                                    collectionItemType = collectionItem1.GetType();

                                    if (CanDirectlyCompare(collectionItemType))
                                    {
                                        if (!AreValuesEqual(collectionItem1, collectionItem2))
                                        {
                                            //Console.WriteLine("Item {0} in property collection '{1}.{2}' does not match.", i, objectType.FullName, propertyInfo.Name);
                                            _DiffList.Add(new ValueDifference(objectType, propertyInfo, i));
                                            result = false;
                                        }
                                    }
                                    else
                                    {
                                        ObjectsDifferentiator objectsDifferentiator = new ObjectsDifferentiator(propertyInfo.GetValue(_objectA, null), propertyInfo.GetValue(_objectB, null), _ignoreList);
                                        if (!objectsDifferentiator.AreObjectsEqual())
                                        {
                                            Console.WriteLine("Item {0} in property collection '{1}.{2}' does not match.", i, objectType.FullName, propertyInfo.Name);
                                            result = false;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else if (propertyInfo.PropertyType.IsClass)
                    {
                        ObjectsDifferentiator objectsDifferentiator = new ObjectsDifferentiator(propertyInfo.GetValue(_objectA, null), propertyInfo.GetValue(_objectB, null), _ignoreList);
                        if (!objectsDifferentiator.AreObjectsEqual())
                        {
                            Console.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                            result = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot compare property '{0}.{1}'.", objectType.FullName, propertyInfo.Name);
                        result = false;
                    }
                }
            }
            else
                result = Equals(_objectA, _objectB);

            return result;
        }

        /// <summary>
        /// Determines whether value instances of the specified type can be directly compared.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if this value instances of the specified type can be directly compared; otherwise, <c>false</c>.
        /// </returns>
        private bool CanDirectlyCompare(Type type)
        {
            return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
        }

        /// <summary>
        /// Compares two values and returns if they are the same.
        /// </summary>
        /// <param name="valueA">The first value to compare.</param>
        /// <param name="valueB">The second value to compare.</param>
        /// <returns><c>true</c> if both values match, otherwise <c>false</c>.</returns>
        private bool AreValuesEqual(object valueA, object valueB)
        {
            bool result;
            IComparable selfValueComparer;

            selfValueComparer = valueA as IComparable;

            if (valueA == null && valueB != null || valueA != null && valueB == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                result = false; // the comparison using IComparable failed
            else if (!Equals(valueA, valueB))
                result = false; // the comparison using Equals failed
            else
                result = true; // match

            return result;
        }

        private List<Difference> _DiffList;

    }
}
