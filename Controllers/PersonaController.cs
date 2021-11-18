using API.Services;
using API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace API.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly ISectorZona _sectorZona;

        public PersonaController(IPersonaRepositorio personaRepositorio, ISectorZona sectorZona)
        {
            _personaRepositorio = personaRepositorio ?? throw new ArgumentNullException(nameof(personaRepositorio));
            _sectorZona = sectorZona ?? throw new ArgumentNullException(nameof(sectorZona));
        }
        
        [HttpGet("listarPersonas")]
        public ActionResult Get()
        {
            /*using (Models.DB_Sector_ZonaContext db = new Models.DB_Sector_ZonaContext()) {

                // Sintaxis en Linq
                var lst = (from p in db.TblPersonas
                           join sector in db.TblSectors on p.CodSector equals sector.CodSector
                           join zona in db.TblZonas on p.CodZona equals zona.CodZona
                           select new { p.CodPersona, p.NomPersona, p.FecNacimiento, sector.DesSector, 
                           zona.DesZona, p.Sueldo }).ToList();
            }*/
            var lst = _personaRepositorio.GetPersonas();
            return Ok(new ObjResult<IEnumerable>
            {
                Status = StatusCodes.Status200OK,
                Result = lst
            });
        }

        [HttpPost("crear")]
        public ActionResult Post([FromBody] Models.Request.PersonaRequest model)
        {   
            var result = _personaRepositorio.CrearPersona(model);

            if(result)
            {
                return Ok(new ObjResult<String>
                {
                    Status = StatusCodes.Status200OK,
                    Result = "Registro de persona creado correctamente"
                });
            }
            else
            {
                return BadRequest(new ObjResult<String>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Result = "Error. No se pudo crear el registro de la persona"
                });
            }
        }

        [HttpPut("actualizar")]
        public ActionResult Put([FromBody] Models.Request.PersonaRequest model)
        {
            var result = _personaRepositorio.ActualizarDatos(model);

            if (result)
            {
                return Ok(new ObjResult<String> { 
                    Status = StatusCodes.Status200OK,
                    Result = "Registro actualizado correctamente"
                });
            }
            else
            {
                return BadRequest(new ObjResult<String> { 
                    Status = StatusCodes.Status400BadRequest,
                    Result = "Error, no se ha podido actualizar el registro"
                });
            }
        }

        [HttpDelete("eliminar")]
        public ActionResult Delete([FromBody] Models.Request.PersonaRequest model)
        {
            var result = _personaRepositorio.EliminarDatos(model);

            if (result)
            {
                return Ok(new ObjResult<String> { 
                    Status = StatusCodes.Status200OK,
                    Result = "Se ha eliminado el registro correctamente"
                });
            }
            else
            {
                return BadRequest(new ObjResult<String> { 
                    Status = StatusCodes.Status400BadRequest,
                    Result = "Error, no se ha podido eliminar el registro"
                });
            }
        }

        [HttpPost("consultarPersonaSueldo")]
        public ActionResult Post([FromBody] Models.Request.ZonaRequest model)
        {
            /*using (Models.DB_Sector_ZonaContext db = new Models.DB_Sector_ZonaContext())
            {
                DateTime fechaActual = DateTime.Now;

                var lst = db.TblPersonas.Where(p => p.CodZona == model.CodZona &&
                          fechaActual.Year - p.FecNacimiento.Year < 65)
                          .Select(persona => new
                          {
                              CodPersona = persona.CodPersona,
                              NomPersona = persona.NomPersona,
                              Sueldo = persona.Sueldo
                          }).ToList();

                return Ok(lst);
            }*/
            var lst = _sectorZona.GetSueldoXPersona(model);
            return Ok(new ObjResult<IEnumerable> { 
                Status = StatusCodes.Status200OK,
                Result = lst
            });
        }
    }
}
