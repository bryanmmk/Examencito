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
    public class AdministracionRepository : IBaseRepository<Administracion, Guid>
    {

        private FarmaciaDB db;

        public AdministracionRepository(FarmaciaDB db)
        {
            this.db = db;
        }

        public Administracion Create(Administracion administracion)
        {
            administracion.ID = Guid.NewGuid();
            db.Administracions.Add(administracion);
            return administracion;
        }

        public void Delete(Guid entityId)
        {
            var selectedAdministracion = db.Administracions
                 .Where(u => u.ID == entityId).FirstOrDefault();
            if (selectedAdministracion != null)
                db.Administracions.Remove(selectedAdministracion);
        }

        public List<Administracion> GetAll()
        {
            return db.Administracions.ToList();
        }

        public Administracion GetById(Guid entityId)
        {
            var SelectedAdministracion = db.Administracions
                .Where(u => u.ID == entityId).FirstOrDefault();
            return SelectedAdministracion;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Administracion Update(Administracion administracion)
        {
            var SelectedAdministracion = db.Administracions
                    .Where(u => u.ID == administracion.ID)
                    .FirstOrDefault();
            if (SelectedAdministracion != null)
            {
                SelectedAdministracion.Usuario = administracion.Usuario;
                SelectedAdministracion.contra = administracion.contra ;


                db.Entry(SelectedAdministracion).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedAdministracion;
        }
    }
}
