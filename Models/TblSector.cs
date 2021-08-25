using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblSector
    {
        public TblSector()
        {
            TblPersonas = new HashSet<TblPersona>();
            TblZonas = new HashSet<TblZona>();
        }

        public int CodSector { get; set; }
        public string DesSector { get; set; }

        public virtual ICollection<TblPersona> TblPersonas { get; set; }
        public virtual ICollection<TblZona> TblZonas { get; set; }
    }
}
