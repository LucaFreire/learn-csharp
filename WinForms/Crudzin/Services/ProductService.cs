using Crudzin.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudzin.Services
{
    public class ProductService : IProductService
    {

        CrudWinformsContext context;
        public ProductService(CrudWinformsContext ctx)
            => this.context = ctx;

        public async Task<Produto?> GetByName(string name)
            => await this.context.Produtos.FirstOrDefaultAsync(prod => prod.Nome == name);
        public async Task<Produto?> GetByID(int ID)
            => await this.context.Produtos.FirstOrDefaultAsync(prod => prod.Id == ID);

    }
}
