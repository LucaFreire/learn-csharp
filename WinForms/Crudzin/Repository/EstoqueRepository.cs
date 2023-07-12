using Crudzin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudzin.Repository
{
    internal class EstoqueRepository : IRepository<Estoque>
    {
        CrudWinformsContext context;
        public EstoqueRepository(CrudWinformsContext ctx)
            => this.context = ctx;

        public async Task<bool> Create(Estoque obj)
        {
            try
            {
                await this.context.Estoques.AddAsync(obj);
                await this.context.SaveChangesAsync();
                return true;
            } 
            catch { return false; }
        }

        public async Task<bool> Delete(Estoque obj)
        {
            try
            {
                this.context.Estoques.Remove(obj);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(Estoque obj)
        {
            try
            {
                this.context.Estoques.Update(obj);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
   
}