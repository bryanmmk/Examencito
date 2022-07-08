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
    public class MedicamentosRepository : IBaseRepository<Medicamentos, Guid>
    {
        private FarmaciaDB db;

        public MedicamentosRepository(FarmaciaDB db)
        {
            this.db = db;
        }

        public Medicamentos Create(Medicamentos medicamentos)
        {
            medicamentos.ID_Medicamento = Guid.NewGuid();
            db.Medicamentoss.Add(medicamentos);
            return medicamentos;
        }

        public void Delete(Guid entityId)
        {
            var selectedMedicamentos = db.Medicamentoss
                .Where(u => u.ID_Medicamento == entityId).FirstOrDefault();
            if (selectedMedicamentos != null)
                db.Medicamentoss.Remove(selectedMedicamentos);
        }

        public List<Medicamentos> GetAll()
        {
            return db.Medicamentoss.ToList();
        }

        public Medicamentos GetById(Guid entityId)
        {
            var SelectedMedicamentos = db.Medicamentoss
                .Where(u => u.ID_Medicamento == entityId).FirstOrDefault();
            return SelectedMedicamentos;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Medicamentos Update(Medicamentos medicamentos)
        {
            var SelectedMedicamentos = db.Medicamentoss
                    .Where(u => u.ID_Medicamento == medicamentos.ID_Medicamento)
                    .FirstOrDefault();
            if (SelectedMedicamentos != null)
            {
                SelectedMedicamentos.Nombre = medicamentos.Nombre;
                SelectedMedicamentos.Descripcion = medicamentos.Descripcion;
                SelectedMedicamentos.Precio = medicamentos.Precio;
                SelectedMedicamentos.Imagen = medicamentos.Imagen;

                db.Entry(SelectedMedicamentos).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedMedicamentos;
        }
    }
}
