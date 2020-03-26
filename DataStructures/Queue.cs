using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Queue<T> : IReadOnlyCollection<T>, IEnumerable<T>
    {
        public int Count => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
