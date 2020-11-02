1. crear el proyecto (Aplicacion WEB ASP.NET Core)
Nombre RecursosHumanos
tipo api.
sin configurar https.

2.
crear la carpeta "Controllers"
crear la carpeta "Servicios"
crear la carpeta "Repositorio"
crear la carpeta "Entidades" dentro de repositorio

crear la interfaz IRepositorio dentro de Repositorio
crear la clase Empleado dentro de "Entidades"
crear la clase Memoria dentro de "Repositorio"

Se implementa en memoria la interfaz IRepositorio
Esta Memoria es una clase genrica (para manejr cualquier entidad)

OJO: en el startup se puede colocar la inyeccion, ya sea memoria o de db
(nada de pruebas unitarias)


3. bulk API Servicios
en servicios crear carpeta "Archivo"
y dentro:
- ICargarArchivo
- CSV
- FabricaArchivo
y luego:
- BulkService

4. Bulk controller
- agregar Controller
- escoger Controlador API vacio
- colocarle el controlador BulkController
- implementarlo de una vez
https://stackoverflow.com/questions/10320232/how-to-accept-a-file-post
https://www.c-sharpcorner.com/UploadFile/2b481f/uploading-a-file-in-Asp-Net-web-api/


5. EmpleadoService
crear EmpleadoService

6. implementar el empleadocontroller
- agregar Controller
- escoger Controlador API vacio
- colocarle el controlador EmpleadoController
- implementarlo de una vez
