using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUsuario
    {
        int GetUsuario([FromBody] Models.Request.UsuarioRequest model);
    }
}
