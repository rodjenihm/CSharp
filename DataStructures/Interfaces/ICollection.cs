using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ICollection<T>
    {
        int Count { get; }

        void Add(T item);
        void Clear();
        bool Contains(T item);
    }
}
