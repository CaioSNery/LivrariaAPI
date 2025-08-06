using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Maps
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("Locação");

            builder.Property(a => a.ValorTotal)
            .HasColumnType("decimal(18,2)");

            builder.HasOne(c => c.Cliente)
            .WithMany()
            .HasForeignKey(c => c.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Produto)
            .WithMany()
            .HasForeignKey(p => p.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}