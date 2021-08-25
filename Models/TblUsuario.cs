using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblUsuario
    {
        public int CodUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string Password { get; set; }
    }
}
