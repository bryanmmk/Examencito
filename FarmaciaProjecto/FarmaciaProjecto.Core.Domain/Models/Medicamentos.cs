using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Models
{
    public class Medicamentos
    {
        public Guid ID_Medicamento { get; set; }
        public string Nombre { get; set; }
        public Guid ID_Categoria { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public Categoria Categoria { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<Pedido> Pedidos { get; set; }


    }
}
