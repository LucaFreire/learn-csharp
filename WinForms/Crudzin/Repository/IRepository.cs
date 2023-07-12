using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudzin.Repository
{
    public interface IRepository<T>
    {
        Task<bool> Create(T obj);
        Task<bool> Delete(T obj);
        Task<bool> Update(T obj);
    }
}
