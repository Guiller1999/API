using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblPersona
    {
        public int CodPersona { get; set; }
        public string NomPersona { get; set; }
        public DateTime FecNacimiento { get; set; }
        public int CodSector { get; set; }
        public int CodZona { get; set; }
        public decimal Sueldo { get; set; }

        public virtual TblSector CodSectorNavigation { get; set; }
        public virtual TblZona CodZonaNavigation { get; set; }
    }
}
