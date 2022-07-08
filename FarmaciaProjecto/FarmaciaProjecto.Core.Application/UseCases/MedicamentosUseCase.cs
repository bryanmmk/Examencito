using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;


namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class MedicamentosUseCase : IBaseUseCase<Medicamentos,Guid>
    {
        private readonly IBaseRepository<Medicamentos, Guid> repository;
        public MedicamentosUseCase(IBaseRepository<Medicamentos, Guid> repository)
        {
            this.repository = repository;
        }
        public Medicamentos Create(Medicamentos entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. Medicamento no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<Medicamentos> GetAll()
        {
            return repository.GetAll();
        }
        public Medicamentos GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public Medicamentos Update(Medicamentos entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
