using System;
using System.Collections.Generic;
using System.Text;
using FarmaciaProjecto.Core.Domain.Models;
using FarmaciaProjecto.Core.Application.Interfaces;
using FarmaciaProjecto.Core.Infraestructure.Repository.Abstract;

namespace FarmaciaProjecto.Core.Application.UseCases
{
    public class PedidoUseCase : IBaseUseCase<Pedido, Guid>
    {
        private readonly IBaseRepository<Pedido, Guid> repository;
        public PedidoUseCase(IBaseRepository<Pedido, Guid> repository)
        {
            this.repository = repository;
        }
        public Pedido Create(Pedido entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. Pedido no puede ser nulo");
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }
        public List<Pedido> GetAll()
        {
            return repository.GetAll();
        }
        public Pedido GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }
        public Pedido Update(Pedido entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
