using System;
using System.Collections.Generic;

namespace Crudzin.Model;

public partial class Estoque
{
    public int Id { get; set; }

    public int? FkProduto { get; set; }

    public int? Quantidade { get; set; }

    public virtual Produto? FkProdutoNavigation { get; set; }
}
