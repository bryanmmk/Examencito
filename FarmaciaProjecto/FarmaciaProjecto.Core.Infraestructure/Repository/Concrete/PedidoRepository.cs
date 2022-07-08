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
    public class PedidoRepository : IBaseRepository<Pedido, Guid>
    {

        private FarmaciaDB db;

        public PedidoRepository(FarmaciaDB db)
        {
            this.db = db;
        }


        public Pedido Create(Pedido pedido)
        {
            pedido.ID_Pedido = Guid.NewGuid();
            db.Pedidos.Add(pedido);
            return pedido;
        }

        public void Delete(Guid entityId)
        {
            var selectedPedido = db.Pedidos
               .Where(u => u.ID_Pedido == entityId).FirstOrDefault();
            if (selectedPedido != null)
                db.Pedidos.Remove(selectedPedido);
        }

        public List<Pedido> GetAll()
        {
            return db.Pedidos.ToList();
        }

        public Pedido GetById(Guid entityId)
        {
            var SelectedPedido = db.Pedidos
           .Where(u => u.ID_Pedido == entityId).FirstOrDefault();
            return SelectedPedido;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Pedido Update(Pedido pedido)
        {
            var SelectedPedido = db.Pedidos
                   .Where(u => u.ID_Pedido == pedido.ID_Pedido)
                   .FirstOrDefault();
            if (SelectedPedido != null)
            {
                SelectedPedido.Fecha = pedido.Fecha;
                SelectedPedido.estado = pedido.estado;
                SelectedPedido.Total = pedido.Total;

                db.Entry(SelectedPedido).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedPedido;
        }
    }
}
