using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crudzin.Model;

public partial class CrudWinformsContext : DbContext
{
    public CrudWinformsContext()
    {
    }

    public CrudWinformsContext(DbContextOptions<CrudWinformsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estoque> Estoques { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013G\\SQLEXPRESS;Initial Catalog=CRUD_WINFORMS;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTOQUE__3214EC273F48AFD6");

            entity.ToTable("ESTOQUE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkProduto).HasColumnName("FK_PRODUTO");
            entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE");

            entity.HasOne(d => d.FkProdutoNavigation).WithMany(p => p.Estoques)
                .HasForeignKey(d => d.FkProduto)
                .HasConstraintName("FK__ESTOQUE__FK_PROD__4BAC3F29");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUTO__3214EC27C8C6274B");

            entity.ToTable("PRODUTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Price).HasColumnName("PRICE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
