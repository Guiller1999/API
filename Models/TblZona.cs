using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblZona
    {
        public TblZona()
        {
            TblPersonas = new HashSet<TblPersona>();
        }

        public int CodZona { get; set; }
        public string DesZona { get; set; }
        public int CodSector { get; set; }

        public virtual TblSector CodSectorNavigation { get; set; }
        public virtual ICollection<TblPersona> TblPersonas { get; set; }
    }
}
