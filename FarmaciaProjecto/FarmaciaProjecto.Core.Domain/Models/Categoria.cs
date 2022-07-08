using System;
using System.Collections.Generic;
using System.Text;

namespace FarmaciaProjecto.Core.Domain.Models
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public Guid ID_Categoria { get; set; }
        public List<Medicamentos>Medicamentoss { get; set; }
    }
}
