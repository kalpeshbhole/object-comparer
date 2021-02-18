using System;
using System.Reflection;

namespace Manager
{
    public class ComparerManager : IComparerManager
    {
        public bool Compare<T>(T first, T second)
        {
            if (first == null && second == null)
                return true;
            else if (first == null || second == null)
                return false;
            else if (first.GetType() != second.GetType())
                return false;

            Type type = first.GetType();
            if (type.IsPrimitive || typeof(string).Equals(type))
            {
                return first.Equals(second);
            }
            if (type.IsArray)
            {
                Array firstArr = first as Array;
                Array secondArr = second as Array;

                if (firstArr.Length != secondArr.Length)
                    return false;

                if (firstArr.GetValue(0).GetType().IsPrimitive)
                {
                    Array.Sort(firstArr);
                    Array.Sort(secondArr);
                }

                var en = firstArr.GetEnumerator();
                int i = 0;
                while (en.MoveNext())
                {
                    if (!Compare(en.Current, secondArr.GetValue(i)))
                        return false;
                    i++;
                }
            }
            else
            {
                foreach (PropertyInfo pi in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var val = pi.GetValue(first);
                    var tval = pi.GetValue(second);
                    if (!Compare(val, tval))
                        return false;
                }
                foreach (FieldInfo fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var val = fi.GetValue(first);
                    var tval = fi.GetValue(second);
                    if (!Compare(val, tval))
                        return false;
                }
            }

            return true;
        }
    }
}
