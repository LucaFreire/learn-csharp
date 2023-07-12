using Crudzin.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudzin.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        CrudWinformsContext context;
        public ProdutoRepository(CrudWinformsContext ctx)
            => this.context = ctx;

        public async Task<bool> Create(Produto obj)
        {
            try
            {
                await this.context.Produtos.AddAsync(obj);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> Delete(Produto obj)
        {
            try
            {
                MessageBox.Show($"Id: {obj.Id}");
                MessageBox.Show($"Nome: {obj.Nome}");
                MessageBox.Show($"Price: {obj.Price}");
                this.context.Produtos.Remove(obj);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch(Exception e) { MessageBox.Show(e.Message);return false; }
        }
        public async Task<bool> Update(Produto obj)
        {
            try
            {
                this.context.Produtos.Update(obj);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}