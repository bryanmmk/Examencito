using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Adaptors.SQLServerDataAccess.Entities;
using FarmaciaProjecto.Adaptors.SQLServerDataAccess.Utils;


namespace FarmaciaProjecto.Adaptors.SQLServerDataAccess.Contexts
{
    public class FarmaciaDB : DbContext
    {
        public DbSet<Usuario>Usuarios { get; set; }
        public DbSet<Categoria>Categorias { get; set; }
        public DbSet<Pedido>Pedidos { get; set; }
        public DbSet<Medicamentos>Medicamentoss { get; set; }
        public DbSet<DetallePedido>DetallePedidos { get; set; }
        public DbSet<Administracion>Administracions { get; set; }
        public DbSet<Proveedor>Proveedors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EUsuario());
            builder.ApplyConfiguration(new EProveedor());
            builder.ApplyConfiguration(new EPedido());
            builder.ApplyConfiguration(new EMedicamento());
            builder.ApplyConfiguration(new EDetallePedido());
            builder.ApplyConfiguration(new ECategoria());
            builder.ApplyConfiguration(new EAdministracion());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSettings.SqlServerConnectionString);
        }
    }
}
