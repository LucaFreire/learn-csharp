using System;
using System.Collections.Generic;

namespace Crudzin.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
}
