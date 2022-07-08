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
    public class DetallePedidoRepository : IBaseRepository<DetallePedido, Guid>
    {

        private FarmaciaDB db;

        public DetallePedidoRepository(FarmaciaDB db)
        {
            this.db = db;
        }


        public DetallePedido Create(DetallePedido detallePedido)
        {
            detallePedido.ID_DetallePedido = Guid.NewGuid();
            db.DetallePedidos.Add(detallePedido);
            return detallePedido;
        }

        public void Delete(Guid entityId)
        {
            var selectedDetallePedido = db.DetallePedidos
            .Where(u => u.ID_DetallePedido == entityId).FirstOrDefault();
            if (selectedDetallePedido != null)
                db.DetallePedidos.Remove(selectedDetallePedido);
        }

        public List<DetallePedido> GetAll()
        {
            return db.DetallePedidos.ToList();
        }

        public DetallePedido GetById(Guid entityId)
        {
            var SelectedDetallePedido = db.DetallePedidos
          .Where(u => u.ID_DetallePedido == entityId).FirstOrDefault();
            return SelectedDetallePedido;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public DetallePedido Update(DetallePedido detallePedido)
        {
            var SelectedDetallePedido = db.DetallePedidos
        .Where(u => u.ID_DetallePedido == detallePedido.ID_DetallePedido)
        .FirstOrDefault();
            if (SelectedDetallePedido != null)
            {
                SelectedDetallePedido.Cantidad = detallePedido.Cantidad;
                SelectedDetallePedido.PrecioUnitario = detallePedido.PrecioUnitario;


                db.Entry(SelectedDetallePedido).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return SelectedDetallePedido;
        }
    }
}
