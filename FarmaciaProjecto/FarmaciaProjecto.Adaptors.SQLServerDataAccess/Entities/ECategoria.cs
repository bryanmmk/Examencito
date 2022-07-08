using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class ECategoria : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tb_Categoria");
            builder.HasKey(u => u.ID_Categoria);

            builder
                .HasMany(u => u.Medicamentoss)
                .WithOne(cat => cat.Categoria);
        }
    }
}
