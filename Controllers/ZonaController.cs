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
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly ISectorZona _sectorZona;

        public ZonaController(ISectorZona sectorZona)
        {
            _sectorZona = sectorZona ?? throw new ArgumentNullException(nameof(sectorZona));
        }

        [HttpPost("listarZonas")]
        public ActionResult Post([FromBody] Models.Request.ZonaRequest model)
        {
            /*using (Models.DB_Sector_ZonaContext db = new Models.DB_Sector_ZonaContext())
            {

                var lst = db.TblZonas.Where(zona => zona.CodSector == model.CodSector).
                    Select(zona => new { zona.CodZona, zona.DesZona, zona.CodSector}).ToList();

                return Ok(lst);

            }*/
            var zonas = _sectorZona.GetZonas(model);
            return Ok(new ObjResult<IEnumerable> { 
                Status = StatusCodes.Status200OK,
                Result = zonas
            });
        }
    }
}
