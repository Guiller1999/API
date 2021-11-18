# API
Este repositorio muestra una API creada mediante la tecnolog�a de .net core 3.1 y el uso del ORM 
Entity Framework para las entidades de la base de datos.

# Prerequisitos para la ejecuci�n de la API
1. Asegurese de primero ejecutar el script DB_Sector_Zona.sql, el cual es la base de datos usada por esta API.
2. Tener instalado los siguientes paquetes NuGet:
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools
	- Swashbuckle.AspNetCore.SwaggerGen
	- Swashbuckle.AspNetCore.SwaggerUI

# Sobre la API
Esta API es la utilizada en la aplicaci�n que se encuentra en el repositorio [PruebaReact](https://github.com/Guiller1999/PruebaReact), entre las funciones que tiene esta API estan la creaci�n,
actualizaci�n, consulta y eliminaci�n de los diferentes registros de personas que tendr�n su nombre, sueldo y que pertenecen a una zona y sector respectivo de la ciudad de Guayaquil. As� mismo
ofrece la posibilidad de consultar las zonas y sectores que se encuentran almacenados en la base de datos.

# Documentaci�n
A continuaci�n se muestran los diferentes endpoints que existen en la API.

## Endpoints
| Verb | Path | Action|
|------|------|-------|






