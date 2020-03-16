using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Extensions
{
    public static class MyLing
    {
        public static int Count<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (source is ICollection<T> sourceAsCollection)
            {
                return sourceAsCollection.Count;
            }

            int counter = 0;

            var e = source.GetEnumerator();

            while (e.MoveNext())
            {
                counter++;
            }

            return counter;
        }
    }
}
