using API.Models;
using API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class Usuario : IUsuario
    {
        private readonly DB_Sector_ZonaContext _dbContext;

        public Usuario(DB_Sector_ZonaContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int GetUsuario([FromBody] UsuarioRequest model)
        {
                try
                {
                    var lst = _dbContext.TblUsuarios.Count(usuario => 
                            usuario.NomUsuario == model.NomUsuario &&
                            usuario.Password == model.Password);

                    return lst;
                }
                catch(Exception e)
                {
                    if(e is ArgumentNullException || e is OverflowException)
                        return -1;
                    return -1;
                }
        }
    }
}
