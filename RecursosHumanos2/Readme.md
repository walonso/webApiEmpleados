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

f. desplegar a docker. (windows)
https://docs.docker.com/engine/examples/dotnetcore/
- crear folder dentroo del proy (docker)
- crear carpeta windows y archivo Dockerfile
(Open the Dockerfile in a text editor such as Visual Studio Code. The Dockerfile script creates a Windows Server container with all requirements including .NET Core run-times and Visual C++ Redistributables.)
- linea de comandos apunte a la carpeta publish y ejecutar comando: (-t es de tag)
docker build -t rrhh:1.0 .
- corra el container:
docker run -d -p 5000:80 --name rrhhapp rrhh:1.0
- ya se puede ver en el UI de docker q la aplicacion está corriendo


7.2 desplegar a Azure web Service windows
https://docs.microsoft.com/es-es/azure/app-service/overview-hosting-plans
- crear app service en azure. en windows
** testrrhhwindows
** net core 3.1 windows
- publicar usando visual studio.

7.3 desplegar a Azure app Service windows

7.4 desplegar a Azure app Service linux

7.5 desplegar a azure app service container
https://docs.microsoft.com/en-us/visualstudio/containers/overview?view=vs-2019

7.8 Container Instances. (puede usar una imagen externa o uno registrado en el azure container registry)
https://docs.microsoft.com/en-us/azure/container-instances/container-instances-quickstart-portal

8. Como manejar los secretos:
8.1 Key vault:
https://docs.microsoft.com/en-us/azure/key-vault/general/tutorial-net-create-vault-azure-web-app
- crea el key vult.
- agregar la referncia al proyecto using Azure.Security.KeyVault.Secrets;
- agergar el codigo en el controller empleado:
//Key vault
            /*SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
            };
            var client = new SecretClient(new Uri("https://keyvaulttestrrhh.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("secretotestrrhh");

            string secretValue = secret.Value;



8.2 User management:
https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows
en el propio server se almacenan estas llaves, cada desarrollador las pondra en su maquina en un json.
Al desplegarlo en un azure app service es configyurar un nuev secreto en Configuracion / Configuracion de la aplicacion.

8.3 App Configurati0n:
usa el user management del punto anterior, sin embargo, este se conecta al component "App configuration" de azure portal.
https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core3x





- Kubernetes
- Service Fabric
- VMs?
- Azure function?