using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Maps
{
    public class VendaMap : IEntityTypeConfiguration<Vendas>
    {
        public void Configure(EntityTypeBuilder<Vendas> builder)
        {
            builder.ToTable("Vendas");

            builder.Property(v => v.ValorTotal)
            .HasColumnType("decimal(18,2)");

            builder.Property(v => v.PrecoUnitario)
            .HasColumnType("decimal(18,2)");

            builder.HasOne(v => v.Produto)
            .WithMany()
            .HasForeignKey(p => p.IdProduto)
            .OnDelete(DeleteBehavior.Cascade);




        }
    }
}