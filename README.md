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
| GET  | api/codigo/consultar | Obtiene el ID del �ltimo registro creado para una persona | 
| GET  | api/persona/listarPersonas | Obtiene la informaci�n de todas las personas registradas |
| POST | api/persona/crear | Crea un nuevo registro de persona |
| PUT  | api/persona/actualizar | Actualiza la informaci�n de una persona |
| DELETE | api/persona/eliminar | Elimina el registro de una persona mediante el c�digo de dicha persona |
| POST | api/persona/consultarPersonaSueldo | Obtiene una lista de todas las personas con su sueldo respectivo mediante el codigo de zona |
| GET  | api/sector/listar | Obtiene una lista de todos los sectores registrados |
| POST | api/usuario/login | Envia las credenciales para la autenticaci�n del usuario |
| POST | api/zona/listarZonas | Obtiene una lista de las zonas por el c�digo del sector |
| GET  | api/zonasector/consultarZonaSector | Obtiene una lista de todos los sectores y el total de sueldos en dicho sector agrupados por zonas | 

## Ejemplos del uso de la API
### Validaci�n de inicio de sesi�n
Para iniciar sesi�n debe de usar el path:

```
    api/usuario/login
```
Y agregar este cuerpo a la solicitud HTTP
```json
{
	"nomUsuario": "admin",
	"password": "123"
}
```
El resultado enviado por el servidor ser� el siguiente 
```json
{
	"status": 200,
	"result": true
}
```
Donde status har� referencia al estado de la petici�n HTTP y result traer� el resultado que se espera, en este caso **true** que significa
que las credenciales de usuario son correctas.

### Creaci�n de registro de nueva persona
Para crear un registro para una nueva persona deber� usar el path:
```
	api/persona/crear
```
Y agregar este cuerpo a la solicitud HTTP
```json
{
	"codPersona": 6,
	"nomPersona": "Viviana Gonz�lez",
	"fecNacimiento": "1993-11-18",
	"codSector": 1,
	"codZona": 2,
	"sueldo": 650
}
```
El resultado enviado por el servidor ser� el siguiente 
```json
{
	"status": 200,
	"result": "Registro de persona creado correctamente"
}
```
Para la actualizaci�n de la informaci�n de una persona puede usar el mismo formato json que se uso para la creaci�n de la persona.

### Eliminaci�n del registro de una persona
Para eliminar el registro en base de datos de una persona deber� usar el path:
```
	api/persona/eliminar
```
Y agregar este cuerpo a la solicitud HTTP
```json
{
	"codPersona": 6
}
```
El resultado enviado por el servidor ser� el siguiente 
```json
{
	"status": 200,
	"result": "Se ha eliminado el registro correctamente"
}
```

### Consulta de personas y sus sueldos por zonas
Para consultar las personas con sus respectivos sueldos mediante las zonas a las que pertenecen deber� de usar el path:
```
	api/persona/consultarPersonaSueldo
```
Y agregar este cuerpo a la solicitud HTTP
```json
{
	"codZona": 3
}
```
El resultado enviado por el servidor ser� el siguiente 
```json
{
	"status": 200,
	"result": [
      {
		"codPersona": 3,
		"nomPersona": "Guillermo Rivera",
		"sueldo": 500
      },
	  {
		"codPersona": 4,
		"nomPersona": "Carlos Alc�var",
		"sueldo": 560
	  }
	]
}
```