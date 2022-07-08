using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Models
{
    public class Pedido
    {
        public Guid ID_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public string estado { get; set; }
        public Guid ID_Medicamento { get; set; }
        [ForeignKey("ID_Medicamento")]
        public Medicamentos Medicamentos { get; set; }
        public Guid ID_Usuario{ get; set; }
        [ForeignKey("ID_Usuario")]
        public double Total { get; set; }
        public Usuario Usuarios { get; set; }
        public List<DetallePedido> DetallePedidos { get; set; }

        


    }
}
