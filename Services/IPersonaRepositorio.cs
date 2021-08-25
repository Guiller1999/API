using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IPersonaRepositorio
    {
        IEnumerable GetPersonas();
        bool CrearPersona([FromBody] Models.Request.PersonaRequest model);
        bool ActualizarDatos([FromBody] Models.Request.PersonaRequest model);
        bool EliminarDatos([FromBody] Models.Request.PersonaRequest model);
    }
}
