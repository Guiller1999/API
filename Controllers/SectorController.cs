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
    public class SectorController : ControllerBase
    {
        private readonly ISectorZona _sectorZona;

        public SectorController(ISectorZona sectorZona)
        {
            _sectorZona = sectorZona?? throw new ArgumentNullException(nameof(sectorZona));
        }

        [HttpGet]
        public ActionResult Get()
        {
            /*using (Models.DB_Sector_ZonaContext db = new Models.DB_Sector_ZonaContext())
            {
                // Sintaxis Linq
                var lst = (from sector in db.TblSectors
                           select sector).ToList();
                // Sintaxis con Lambda
                
            }*/
            var sectores = _sectorZona.GetSectores();
            return Ok(new ObjResult<IEnumerable>
            {
                Status = StatusCodes.Status200OK,
                Result = sectores
            });
        }
    }
}
