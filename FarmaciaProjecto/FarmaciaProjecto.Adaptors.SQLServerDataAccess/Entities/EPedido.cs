using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class EPedido : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("tb_Pedido");
            builder.HasKey(u => u.ID_Pedido );

            builder
                .HasOne(u =>u.Medicamentos)
                .WithMany(p => p.Pedidos);

            builder
                .HasOne(u => u.Usuarios)
                .WithMany(p => p.Pedidos);

        }
    }
}
