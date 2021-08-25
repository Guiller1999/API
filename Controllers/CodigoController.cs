using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public ActionResult Get()
        {
            
            var result = _codigo.GetUltimoCod();

            if(result != -1)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
