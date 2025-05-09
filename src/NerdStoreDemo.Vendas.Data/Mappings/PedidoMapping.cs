﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NerdStoreDemo.Vendas.Domain;

namespace NerdStoreDemo.Vendas.Data.Mappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Codigo)
            .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

        // 1 : N => Pedido : PedidoItems
        builder.HasMany(c => c.PedidoItems)
            .WithOne(c => c.Pedido)
            .HasForeignKey(c => c.PedidoId);

        builder.ToTable("Pedidos");
    }
}
