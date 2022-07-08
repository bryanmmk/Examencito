using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Models
{
    public class DetallePedido
    {
        public Guid ID_DetallePedido { get; set; }
        public double PrecioUnitario { get; set; }
        public Guid ID_Pedido{ get; set; }
        [ForeignKey("ID_Pedido")]
        public Pedido Pedidos { get; set; }
        public int Cantidad { get; set; }

    }
}
