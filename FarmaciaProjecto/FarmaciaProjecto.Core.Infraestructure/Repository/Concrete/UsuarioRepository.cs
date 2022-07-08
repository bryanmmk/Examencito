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
    public class UsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        private FarmaciaDB db;
        public UsuarioRepository(FarmaciaDB db)
        {
            this.db = db;
        }

        public Usuario Create(Usuario usuario)
        {
            usuario.ID_Usuario = Guid.NewGuid();
            db.Usuarios.Add(usuario);
            return usuario;
        }

        public void Delete(Guid entityId)
        {
            var selectedUsuario = db.Usuarios
                .Where(u => u.ID_Usuario == entityId).FirstOrDefault();
            if (selectedUsuario != null)
                db.Usuarios.Remove(selectedUsuario);
        }

        public List<Usuario> GetAll()
        {
            return db.Usuarios.ToList();

        }

        public Usuario GetById(Guid entityId)
        {
            var SelectedUsuario = db.Usuarios
                .Where(u => u.ID_Usuario == entityId).FirstOrDefault();
            return SelectedUsuario;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Usuario Update(Usuario usuario)
        {
            var SelectedUsuario = db.Usuarios
                   .Where(u => u.ID_Usuario == usuario.ID_Usuario)
                   .FirstOrDefault();
            if (SelectedUsuario != null)
            {
                SelectedUsuario.Nombre = usuario.Nombre;
                SelectedUsuario.Contraseña = usuario.Contraseña;
                SelectedUsuario.Direccion = usuario.Direccion;
                SelectedUsuario.Email = usuario.Email;
                SelectedUsuario.Telefono = usuario.Telefono;

                db.Entry(SelectedUsuario).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedUsuario;
        }
    }
}
