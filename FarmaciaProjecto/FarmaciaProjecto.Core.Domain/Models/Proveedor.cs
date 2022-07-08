using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Models
{
    public class Proveedor
    {
        public Guid ID_Proveedor { get; set; }
        public string Nombre { get; set; }
        public int Codigo_Proveedor { get; set; }
        public List<Medicamentos> Medicamentos { get; set; }

    }
}
