using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class EUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_Usuario");
            builder.HasKey(u => u.ID_Usuario);

            builder
                .HasMany(u => u.Pedidos)
                .WithOne(us => us.Usuarios);
        }
    }
}
