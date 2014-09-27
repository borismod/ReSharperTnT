using System.Collections.Generic;

namespace ReSharperTnT.Tests
{
    public static class ObjectExtensions
    {
        public static List<T> AsList<T>(this T @object)
        {
            return new List<T>() {@object};
        }
    }
}