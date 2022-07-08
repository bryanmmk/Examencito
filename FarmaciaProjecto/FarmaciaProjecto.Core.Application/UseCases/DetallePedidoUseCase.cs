using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;

namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class DetallePedidoUseCase : IBaseUseCase<DetallePedido, Guid>
    {
        private readonly IBaseRepository<DetallePedido, Guid> repository;
        public DetallePedidoUseCase(IBaseRepository<DetallePedido, Guid> repository)
        {
            this.repository = repository;
        }
        public DetallePedido Create(DetallePedido entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. DetallePedido no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<DetallePedido> GetAll()
        {
            return repository.GetAll();
        }
        public DetallePedido GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public DetallePedido Update(DetallePedido entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
