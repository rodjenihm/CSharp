using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IEnumerator<T>
    {
        T Current { get; }
        bool MoveNext();
        void Reset();
    }
}
