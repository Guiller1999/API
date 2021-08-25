using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaController(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio ?? throw new ArgumentNullException(nameof(personaRepositorio));
        }
        
        [HttpGet]
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
            return Ok(lst);
        }

        [HttpPost]
        public bool Post([FromBody] Models.Request.PersonaRequest model)
        {            
            return _personaRepositorio.CrearPersona(model);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.PersonaRequest model)
        {
            var result = _personaRepositorio.ActualizarDatos(model);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.PersonaRequest model)
        {
            
            var result = _personaRepositorio.EliminarDatos(model);

            if(result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
