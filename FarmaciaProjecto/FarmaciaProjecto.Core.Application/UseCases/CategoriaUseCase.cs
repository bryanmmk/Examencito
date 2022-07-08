using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;

namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class CategoriaUseCase : IBaseUseCase<Categoria,Guid>
    {
        private readonly IBaseRepository<Categoria, Guid> repository;
        public CategoriaUseCase(IBaseRepository<Categoria, Guid> repository)
        {
            this.repository = repository;
        }
        public Categoria Create(Categoria entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. Categoria no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<Categoria> GetAll()
        {
            return repository.GetAll();
        }
        public Categoria GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public Categoria Update(Categoria entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
