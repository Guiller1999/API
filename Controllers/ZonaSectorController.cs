using API.Services;
using API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace API.Controllers
{
    [Route("api/zonasector")]
    [ApiController]
    public class ZonaSectorController : ControllerBase
    {
        private readonly ISectorZona _sectorZona;

        public ZonaSectorController(ISectorZona sectorZona)
        {
            _sectorZona = sectorZona ?? throw new ArgumentNullException(nameof(sectorZona));
        }

        [HttpGet("consultarZonaSector")]
        public ActionResult Get()
        {
            /*using(Models.DB_Sector_ZonaContext db = new Models.DB_Sector_ZonaContext())
            {
                DateTime fechaActual = DateTime.Now;

                var lst = db.TblPersonas.Join(
                    db.TblSectors, persona => persona.CodSector, sector => sector.CodSector,
                    (persona, sector) => new { persona, sector }
                    ).
                    Join(db.TblZonas, ps => ps.persona.CodZona,
                    zona => zona.CodZona, (ps, zona) => new { ps, zona })
                    .Where(p => fechaActual.Year - p.ps.persona.FecNacimiento.Year < 65)
                    .AsEnumerable()
                    .GroupBy(a => a.zona.DesZona).AsEnumerable()
                    .Select(cl => new
                    {
                        DesSector = cl.First().ps.sector.DesSector,
                        DesZona = cl.First().zona.DesZona,
                        CodZona = cl.First().zona.CodZona,
                        Sueldo = cl.Sum(c => c.ps.persona.Sueldo)
                    }).ToList();

                return Ok(lst);
            }*/

            var lst = _sectorZona.GetSueldoXZonas();
            return Ok(new ObjResult<IEnumerable> { 
                Status = StatusCodes.Status200OK,
                Result = lst
            });
        }
    }
}
