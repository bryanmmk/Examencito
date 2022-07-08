using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class EProveedor : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("tb_Proveedor");
            builder.HasKey(u => u.ID_Proveedor);

            builder
                .HasMany(u => u.Medicamentos)
                .WithOne(pv => pv.Proveedor);


        }
    }
}
