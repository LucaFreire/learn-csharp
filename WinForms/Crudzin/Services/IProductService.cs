using Crudzin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudzin.Services
{
    public interface IProductService
    {
        Task<Produto?> GetByName(string name);
        Task<Produto?> GetByID(int ID);
    }
}
