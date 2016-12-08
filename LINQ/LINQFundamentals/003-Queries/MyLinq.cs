using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Queries
{
    public static class MyLinq
    {

        public static IEnumerable<double> Random()
        {
            var random = new Random();
            while(true)
            {
                yield return random.NextDouble();
            }
        }   

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        // The result will be similar to what linq produces
        // yield gives us a behivour also known as deferred execution
        public static IEnumerable<T> FilterDeferred<T>(this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}
