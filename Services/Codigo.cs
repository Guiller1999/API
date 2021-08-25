using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class Codigo : ICodigo
    {
        private readonly DB_Sector_ZonaContext _dbContext;

        public Codigo(DB_Sector_ZonaContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int GetUltimoCod()
        {
                try
                {
                    var id = _dbContext.TblPersonas.Max(p => p.CodPersona);
                    return id;
                }
                catch (ArgumentNullException)
                {
                    return -1;
                }
        }
    }
}
