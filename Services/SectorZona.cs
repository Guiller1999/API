using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class SectorZona : ISectorZona
    {
        private readonly DB_Sector_ZonaContext _dbContext;

        public SectorZona(DB_Sector_ZonaContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable GetSectores()
        {
            var sectores = _dbContext.TblSectors.Select(sector => new { sector.CodSector, sector.DesSector }).ToList();
            return sectores;
        }

        public IEnumerable GetSueldoXPersona([FromBody] Models.Request.ZonaRequest model)
        {
                DateTime fechaActual = DateTime.Now;

                var lst = _dbContext.TblPersonas.Where(p => p.CodZona == model.CodZona &&
                          fechaActual.Year - p.FecNacimiento.Year < 65)
                          .Select(persona => new
                          {
                              CodPersona = persona.CodPersona,
                              NomPersona = persona.NomPersona,
                              Sueldo = persona.Sueldo
                          }).ToList();

                return lst;
        }

        public IEnumerable GetSueldoXZonas()
        {
                DateTime fechaActual = DateTime.Now;

                var lst = _dbContext.TblPersonas.Join(
                    _dbContext.TblSectors, persona => persona.CodSector, sector => sector.CodSector,
                    (persona, sector) => new { persona, sector }
                    ).
                    Join(_dbContext.TblZonas, ps => ps.persona.CodZona,
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

                return lst;
        }

        public IEnumerable GetZonas([FromBody] Models.Request.ZonaRequest model)
        {
                var zonas = _dbContext.TblZonas.Where(zona => zona.CodSector == model.CodSector).
                    Select(zona => new { zona.CodZona, zona.DesZona, zona.CodSector }).ToList();

                return zonas;
        }
    }
}
