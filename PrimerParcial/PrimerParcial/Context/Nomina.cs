using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial.Context
{
    public partial class Nomina
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal? SueldoBruto { get; set; }
        public int Id { get; set; }
    }
}
