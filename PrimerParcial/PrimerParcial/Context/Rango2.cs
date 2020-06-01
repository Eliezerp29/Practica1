using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial.Context
{
    public partial class Rango2
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal? SueldoBruto { get; set; }
        public decimal? Afp { get; set; }
        public decimal? Ars { get; set; }
        public decimal? Sip { get; set; }
        public decimal? Irs { get; set; }
        public decimal? SueldoNeto { get; set; }
        public decimal? TotalRetencion { get; set; }
        public int Id { get; set; }
    }
}
