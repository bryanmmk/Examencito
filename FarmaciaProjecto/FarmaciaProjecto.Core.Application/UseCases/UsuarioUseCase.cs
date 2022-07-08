using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;


namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class UsuarioUseCase : IBaseUseCase<Usuario, Guid>
    {
        private readonly IBaseRepository<Usuario, Guid> repository;
        public UsuarioUseCase(IBaseRepository<Usuario, Guid> repository)
        {
            this.repository = repository;
        }
        public Usuario Create(Usuario entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. Usuario no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<Usuario> GetAll()
        {
            return repository.GetAll();
        }
        public Usuario GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public Usuario Update(Usuario entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
