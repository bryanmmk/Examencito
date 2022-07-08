using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;
using FarmaciaProjecto.Core.Domain.Interfaces;
using FarmaciaProjecto.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;


namespace FarmaciaProjecto.Core.Infraestructure.Repository.Concrete
{
    public class ProveedorRepository : IBaseRepository<Proveedor, Guid>
    {

        private FarmaciaDB db;
        public ProveedorRepository(FarmaciaDB db)
        {
            this.db = db;
        }

        public Proveedor Create(Proveedor proveedor)
        {
            proveedor.ID_Proveedor = Guid.NewGuid();
            db.Proveedors.Add(proveedor);
            return proveedor;
        }

        public void Delete(Guid entityId)
        {
            var selectedProveedor = db.Proveedors
               .Where(u => u.ID_Proveedor == entityId).FirstOrDefault();
            if (selectedProveedor != null)
                db.Proveedors.Remove(selectedProveedor);
        }

        public List<Proveedor> GetAll()
        {
            return db.Proveedors.ToList();
        }

        public Proveedor GetById(Guid entityId)
        {
            var SelectedProveedor = db.Proveedors
               .Where(u => u.ID_Proveedor == entityId).FirstOrDefault();
            return SelectedProveedor;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Proveedor Update(Proveedor proveedor)
        {
            var SelectedProveedor = db.Proveedors
                    .Where(u => u.ID_Proveedor == proveedor.ID_Proveedor)
                    .FirstOrDefault();
            if (SelectedProveedor != null)
            {
                SelectedProveedor.Nombre = proveedor.Nombre;
                SelectedProveedor.Codigo_Proveedor = proveedor.Codigo_Proveedor;

                db.Entry(SelectedProveedor).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedProveedor;
        }
    }
}
