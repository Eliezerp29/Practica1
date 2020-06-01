using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Classes
{
    public class Correos
    {
        public int Id { get; set; }
        public string FromCorreo { get; set; }
        public string ToCorreo { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string Status { get; set; }
    }
}
