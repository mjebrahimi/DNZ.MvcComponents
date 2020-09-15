using System;

namespace DNZ.MvcComponents
{
    internal static class CommonUtility
    {
        public static T NotNull<T>(this T obj, string name, string message = null)
            where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            }

            return obj;
        }

        public static T? NotNull<T>(this T? obj, string name, string message = null)
            where T : struct
        {
            if (!obj.HasValue)
            {
                throw new ArgumentNullException($"{name} : {typeof(T)}", message);
            }

            return obj;
        }

        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }
    }
}
