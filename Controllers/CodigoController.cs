using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Models.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoController : ControllerBase
    {
        private readonly ICodigo _codigo;

        public CodigoController(ICodigo cod)
        {
            _codigo = cod ?? throw new ArgumentNullException(nameof(cod));
        }

        [HttpGet("codigo")]
        public ActionResult Get()
        {
            
            var result = _codigo.GetUltimoCod();

            if (result != -1)
                return Ok(new ObjResult<int> { Status = StatusCodes.Status200OK, Result = result }) ;
            else
                return BadRequest(new ObjResult<String> { Status = StatusCodes.Status400BadRequest, Result = "Error. No se pudo obtener el código"});
        }
    }
}
