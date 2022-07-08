using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;


namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class AdministracionUseCase : IBaseUseCase<Administracion, Guid>
    {
        private readonly IBaseRepository<Administracion, Guid> repository;
        public AdministracionUseCase(IBaseRepository<Administracion, Guid> repository)
        {
            this.repository = repository;
        }
        public Administracion Create(Administracion entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. Administrador no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<Administracion> GetAll()
        {
            return repository.GetAll();
        }
        public Administracion GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public Administracion Update(Administracion entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
