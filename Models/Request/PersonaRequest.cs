using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class PersonaRequest
    {
        public int CodPersona { set; get; }
        public string NomPersona { set; get; }
        public DateTime FecNacimiento { get; set; }
        public int CodSector { set; get; }
        public int CodZona { set; get; }
        public decimal Sueldo { set; get; }

    }
}
