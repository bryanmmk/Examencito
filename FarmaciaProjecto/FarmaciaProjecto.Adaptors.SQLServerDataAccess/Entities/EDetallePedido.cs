using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class EDetallePedido : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("tb_DetallePedido");
            builder.HasKey(u => u.ID_DetallePedido);

            builder
                .HasOne(u => u.Pedidos)
                .WithMany(dp => dp.DetallePedidos);

        }
    }
}
