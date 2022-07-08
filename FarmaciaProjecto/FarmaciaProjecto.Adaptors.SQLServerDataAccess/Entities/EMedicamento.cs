using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class EMedicamento : IEntityTypeConfiguration<Medicamentos>
    {
        public void Configure(EntityTypeBuilder<Medicamentos> builder)
        {
            builder.ToTable("tb_Medicamentos");
            builder.HasKey(u => u.ID_Medicamento);
        }
    }
}
