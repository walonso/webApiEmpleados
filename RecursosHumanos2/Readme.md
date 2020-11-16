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

- usar https://joshclose.github.io/CsvHelper/
- buscar CsvHelper usando nuget y instalarlo.

- sera q cambio por database in memory?
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio

- en startup
* agregar en ConfigureServices(IServiceCollection services)
  -> services.AddControllers();

* Configure(IApplicationBuilder app, IWebHostEnvironment env)
  -> en lugar de:
  //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

Usar:
  app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

** OJO: Async programming

** Ojo: fileupload. (indicar q ahora en net core se usa IFormFile y depende de si es un archivo grande o pequeño)
https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1
-> procesar el archivo:
-> https://stackoverflow.com/questions/36432028/how-to-convert-a-file-into-byte-array-in-memory

#################################
** To avoid the MultiPartBodyLength error, we are going to modify our configuration in the Startup.cs class:
https://code-maze.com/upload-files-dot-net-core-angular/

** Ojo: Configurar CORS:
https://medium.com/nerd-for-tech/how-to-upload-files-in-net-core-web-api-and-react-36a8fbf5c9e8


*¨** Postman:
http://localhost:63391/api/Bulk
#########################################

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


7. Despliegue:
7.1 desplegar a docker local / Kubernetes.

a. download docker (desktop)
https://www.docker.com/get-started
https://docs.docker.com/docker-for-windows/install/

b. instalar y probar:
https://hub.docker.com/editions/community/docker-ce-desktop-windows

c. abrir docker.
d. puede salir un problema de wsl:
https://docs.microsoft.com/en-us/windows/wsl/install-win10
e. en cmd escribir docker version y docker ps.

f. desplegar a docker. (windows con IIS) (donde se publica, todo meterlo a otro folder app)
https://www.textcontrol.com/blog/2020/06/23/deploying-an-aspnet-core-web-applications-to-docker/
https://docs.docker.com/engine/examples/dotnetcore/
https://www.c-sharpcorner.com/article/build-and-deploy-asp-net-webapi-using-docker/
- crear folder dentroo del proy (docker)
- crear carpeta windows y archivo Dockerfile
- publicar la aplicacion aun folder.
(Open the Dockerfile in a text editor such as Visual Studio Code. The Dockerfile script creates a Windows Server container with all requirements including .NET Core run-times and Visual C++ Redistributables.)
- linea de comandos apunte a la carpeta publish y ejecutar comando: (-t es de tag)
docker build -t rrhh:1.0 .





- desplegar a Azure web Service
- Container Instances.
- Service Fabric
- VMs?
- Azure function?