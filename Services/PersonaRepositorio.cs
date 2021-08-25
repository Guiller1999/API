using API.Models;
using API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class PersonaRepositorio:IPersonaRepositorio
    {
        private readonly DB_Sector_ZonaContext _dbContext;

        public PersonaRepositorio(DB_Sector_ZonaContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool ActualizarDatos([FromBody] PersonaRequest model)
        {
                Models.TblPersona persona = _dbContext.TblPersonas.Find(model.CodPersona);
                
                if(persona != null)
                {
                    persona.CodPersona = model.CodPersona;
                    persona.NomPersona = model.NomPersona;
                    persona.FecNacimiento = model.FecNacimiento;
                    persona.CodSector = model.CodSector;
                    persona.CodZona = model.CodZona;
                    persona.Sueldo = model.Sueldo;

                    _dbContext.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _dbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
        }

        public bool CrearPersona([FromBody] PersonaRequest model)
        {
                try
                {
                    Models.TblPersona persona = new Models.TblPersona();
                    persona.CodPersona = model.CodPersona;
                    persona.NomPersona = model.NomPersona;
                    persona.FecNacimiento = model.FecNacimiento;
                    persona.CodSector = model.CodSector;
                    persona.CodZona = model.CodZona;
                    persona.Sueldo = model.Sueldo;

                    _dbContext.Add(persona);
                    _dbContext.SaveChanges();

                    return true;
                }
                catch (Exception )
                {
                    return false;
                }
        }

        public bool EliminarDatos([FromBody] PersonaRequest model)
        {

                Models.TblPersona persona = _dbContext.TblPersonas.Find(model.CodPersona);
                if(persona != null)
                {
                    _dbContext.TblPersonas.Remove(persona);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public IEnumerable GetPersonas()
        {
            var lst = _dbContext.TblPersonas.Join(
                    _dbContext.TblSectors, persona => persona.CodSector, sector => sector.CodSector,
                    (persona, sector) => new { persona, sector }
                    ).
                    Join(_dbContext.TblZonas, ps => ps.persona.CodZona,
                    zona => zona.CodZona, (ps, zona) => new { ps, zona })
                    .Select(p => new
                    {
                        CodPersona = p.ps.persona.CodPersona,
                        NomPersona = p.ps.persona.NomPersona,
                        FecNacimiento = p.ps.persona.FecNacimiento,
                        DesSector = p.ps.sector.DesSector,
                        DesZona = p.zona.DesZona,
                        Sueldo = p.ps.persona.Sueldo,
                        CodSector = p.ps.persona.CodSector,
                        CodZona = p.ps.persona.CodZona
                    }).ToList();

            return lst;
        }
    }
}
