using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FarmaciaProjecto.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities
{
    internal class EAdministracion : IEntityTypeConfiguration<Administracion>
    {
        public void Configure(EntityTypeBuilder<Administracion> builder)
        {
            builder.ToTable("tb_Administracion");
            builder.HasKey(u => u.ID);
        }
    }
}
