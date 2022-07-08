using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;

namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class ProveedorUseCase : IBaseUseCase<Proveedor, Guid>
    {
        private readonly IBaseRepository<Proveedor, Guid> repository;
        public ProveedorUseCase(IBaseRepository<Proveedor, Guid> repository)
        {
            this.repository = repository;
        }
        public Proveedor Create(Proveedor entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. Proveedor no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<Proveedor> GetAll()
        {
            return repository.GetAll();
        }
        public Proveedor GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public Proveedor Update(Proveedor entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
      
}
