using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IEnumerable<out T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
