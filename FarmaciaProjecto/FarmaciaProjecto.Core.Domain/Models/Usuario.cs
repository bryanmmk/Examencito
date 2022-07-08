using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Models
{
    public class Usuario
    {
        public Guid ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public List<Pedido> Pedidos { get; set; }

    }
}
