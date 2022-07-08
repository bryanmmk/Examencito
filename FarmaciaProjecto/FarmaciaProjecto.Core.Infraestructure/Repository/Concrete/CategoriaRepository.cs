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
    public class CategoriaRepository : IBaseRepository<Categoria, Guid>
    {

        private FarmaciaDB db;

        public CategoriaRepository(FarmaciaDB db)
        {
            this.db = db;
        }


        public Categoria Create(Categoria categoria)
        {
            categoria.ID_Categoria = Guid.NewGuid();
            db.Categorias.Add(categoria);
            return categoria;
        }

        public void Delete(Guid entityId)
        {
            var selectedCategoria = db.Categorias
            .Where(u => u.ID_Categoria== entityId).FirstOrDefault();
            if (selectedCategoria != null)
                db.Categorias.Remove(selectedCategoria);
        }

        public List<Categoria> GetAll()
        {
            return db.Categorias.ToList();
        }

        public Categoria GetById(Guid entityId)
        {
            var SelectedCategoria = db.Categorias
            .Where(u => u.ID_Categoria == entityId).FirstOrDefault();
            return SelectedCategoria;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Categoria Update(Categoria categoria)
        {
            var SelectedCategoria = db.Categorias
        .Where(u => u.ID_Categoria == categoria.ID_Categoria)
        .FirstOrDefault();
            if (SelectedCategoria != null)
            {
                SelectedCategoria.Nombre = categoria.Nombre;

                db.Entry(SelectedCategoria).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedCategoria;
        }
    }
}
