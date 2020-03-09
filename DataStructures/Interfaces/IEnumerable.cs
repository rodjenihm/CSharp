using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
