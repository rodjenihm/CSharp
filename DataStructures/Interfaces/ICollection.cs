using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ICollection<T> : IEnumerable<T>
    {
        int Count { get; }

        void Add(T item);
        void Clear();
        bool Contains(T item);
    }
}
