using API.Services;
using API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        [HttpPost("login")]
        public ActionResult Post([FromBody] Models.Request.UsuarioRequest model)
        {
            /*using (Models.DB_Sector_ZonaContext db = new Models.DB_Sector_ZonaContext())
            {
                // Sintaxis Linq
                var lst = (from usuario in db.TblUsuarios
                               where usuario.NomUsuario == model.NomUsuario &&
                               usuario.Password == model.Password
                               select new { usuario.NomUsuario, usuario.Password}).ToList();
            }*/
            var result = _usuario.GetUsuario(model);

            if (result > 0)
            {
                return Ok(new ObjResult<bool>
                {
                    Status = StatusCodes.Status200OK,
                    Result = true
                }
                );
            }
            else 
            { 
                return BadRequest(new ObjResult<bool> 
                { 
                    Status = StatusCodes.Status400BadRequest,
                    Result = false
                });
            }
        }
    }
}
