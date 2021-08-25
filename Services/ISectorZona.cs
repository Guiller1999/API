using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ISectorZona
    {
        IEnumerable GetSectores();
        IEnumerable GetZonas([FromBody] Models.Request.ZonaRequest model);
        IEnumerable GetSueldoXZonas();
        IEnumerable GetSueldoXPersona([FromBody] Models.Request.ZonaRequest model);
    }
}
