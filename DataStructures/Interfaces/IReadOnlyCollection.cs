using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IReadOnlyCollection<out T> : IEnumerable<T>
    {
        int Count { get; }
    }
}
